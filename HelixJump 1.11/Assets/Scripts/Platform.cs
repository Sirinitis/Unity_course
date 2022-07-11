using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private int _speedRotate;
    [SerializeField] private int _speedDestroy = 10;

    private Rigidbody[] _childRigidbody;

    private void Start()
    {
        SectorCount();
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speedRotate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.GetPoints();
            DestroyPlatforms(player);
            Scoring.Multiplicator ++; 
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player.IsDie)
                _speedRotate = 0;
        }
    }
    private void SectorCount()
    {
        _childRigidbody = new Rigidbody[transform.childCount];

        for (int i= 0; i< transform.childCount;i++)
            {
            _childRigidbody[i] = transform.GetChild(i).GetComponent<Rigidbody>(); 
            }
    }
    private void DestroyPlatforms(Player player) 
    {
        Vector3 _force = (transform.position - player.transform.position).normalized;

        foreach (Rigidbody chaild in _childRigidbody) 
        {
            chaild.isKinematic = false;
            chaild.AddForceAtPosition(_force * _speedDestroy, transform.position, ForceMode.Impulse);
        }
    }
}

