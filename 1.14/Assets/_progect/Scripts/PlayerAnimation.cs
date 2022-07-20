using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 _playerTransformOld;
    private Vector3 _playerTransformNew;
    private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        _playerTransformNew = transform.position;
        float speed = ((_playerTransformNew - _playerTransformOld) / Time.deltaTime).magnitude;
         _playerAnimator.SetFloat("Speed", speed);
        _playerTransformOld = _playerTransformNew;
        
    }
}
