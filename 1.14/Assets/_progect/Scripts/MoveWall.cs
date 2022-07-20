using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private Vector3 _wallPosition;
    private bool _check;
    private float _wallLength = 2f;

    private void Start()
    {
        _wallPosition = GetComponent<Transform>().position;
    }
    public void Move()
    {
        transform.position = _wallPosition + new Vector3(0, 0, _check ? 0 : _wallLength);
        _check = !_check;
    }
}
