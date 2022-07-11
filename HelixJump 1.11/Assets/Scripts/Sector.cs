using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private bool _isGoog = true;
    [SerializeField] private Material _goodColor;
    [SerializeField] private Material _badColor;

    private void Awake()
    {
        UpdateMaterial();
    }
    private void UpdateMaterial()
    {
        GetComponent<Renderer>().sharedMaterial = _isGoog ? _goodColor : _badColor;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Scoring.Multiplicator = 1;

        if (!collision.collider.TryGetComponent(out Player player)) return;
        
        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot <= 0.5) return;

        if (_isGoog)
            player.Bounce();
        else
            player.Die();
    }
    private void OnValidate()
    {
        UpdateMaterial();
    }
}
