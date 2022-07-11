using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] private Transform _level;
    [SerializeField] private float _speed;

    private Vector3 _currentMousePosition;
    void Update()
    {
        MovementY();
    }
    private void MovementY()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _currentMousePosition;
            _level.Rotate(0, -delta.x * _speed * Time.deltaTime, 0);
        }

        _currentMousePosition = Input.mousePosition;
    }
}
