using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZone : MonoBehaviour
{
    public static List<GameObject> victim { get; private set; }

    private void Start()
    {
        victim = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("��������! " + other.gameObject.name + " ��������� � ���� ���������!");
        victim.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " ����� � ���������� ����.");
        victim.Remove(other.gameObject);
    }
    private void Update()
    {
        Debug.Log(victim.Count + "- �������� � ���� ���������");
    }
}

