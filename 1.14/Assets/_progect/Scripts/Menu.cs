using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private MoveWall[] _listDoors;

    private void Start()
    {
        _listDoors  = GameObject.FindObjectsOfType<MoveWall>();
    }
    public void DoorMove()
    {
        foreach(MoveWall doors in _listDoors)
        {
            doors.Move();
        }
    }

}
