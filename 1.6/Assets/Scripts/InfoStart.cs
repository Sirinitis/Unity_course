using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            Debug.Log("На старт, внимание, марш!");
    }
}
