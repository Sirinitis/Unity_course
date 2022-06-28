using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
   
    void Update()
    {
        ChangingRotation(rotation);
    }
    private void ChangingRotation(Vector3 rotation)
    {
        Quaternion corner = Quaternion.Euler(rotation * Time.deltaTime);
        transform.rotation = corner * transform.rotation;
    }
}
