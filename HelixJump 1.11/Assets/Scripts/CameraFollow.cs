using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _platformCameraOffset;
    [SerializeField] private float _speed;

    void Update()
    {
        Follow();
    }
    private void Follow()
    {
        if (_player.CurrentPlatform == null) return;
        Vector3 targetPosition = _player.CurrentPlatform.transform.position + _platformCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
