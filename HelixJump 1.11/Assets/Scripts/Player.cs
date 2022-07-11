using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _bounceSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Game _game;

    public Platform CurrentPlatform;
    public bool IsDie { get; private set; }

    public void Finish()
    {
        _rigidbody.velocity = Vector3.zero;
        _game.OnPlayerFinish();
    }
    public void Bounce()
    {
        if (IsDie) return;
        _rigidbody.velocity= new Vector3(0,_bounceSpeed,0);
    }
    public void Die()
    {
        IsDie = true;
        _rigidbody.velocity = Vector3.zero;
        _game.OnPlayerDied();
    }
    public void IgnorDie()
    {
        IsDie = false;
        Bounce();
        _game.ContinueLevel();
    }
    public void GoShop()
    {
        _game.ShopOpen();
    }
    public void GetPoints()
    {
        _game.PlayerGetPoints();
    }
}
