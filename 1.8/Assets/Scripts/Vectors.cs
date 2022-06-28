using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectors : MonoBehaviour
{
    [SerializeField] private Vector3 vector1, vector2;
    [SerializeField] private float multiplicationSize;
    [SerializeField] private bool sum, subtractoin, multiplication, distance;
    [SerializeField] private GameObject[] goals;

    private void Update()
    {
        if (distance)
            Distance(goals);
    }

    private void OnDrawGizmos()
    {
        if (sum)
        {
            DrawVector(vector1, vector2);
            Sum(vector1, vector2);
        }
        if (subtractoin)
        {
            DrawVector(vector1, vector2);
            Subtractoin(vector1, vector2);
        }
        if (multiplication)
            Multiplication(vector1, vector2);
    }
    private void DrawVector(Vector3 vecr, Vector3 vecr1)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, vecr);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, vecr1);
    }
    private void Sum(Vector3 vecr, Vector3 vecr1)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, vecr + vecr1);
    }
    private void Subtractoin(Vector3 vecr, Vector3 vecr1)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + vecr1, vecr - vecr1);
    }
    private void Multiplication(Vector3 vecr, Vector3 vecr1)
    {
        vecr = vecr * multiplicationSize;
        vecr1 = vecr1 * multiplicationSize;
        DrawVector(vecr, vecr1);
    }
    private void Distance(GameObject[] goal)
    {
        Vector3 vector1 = transform.position;
        foreach(GameObject gameObject in goal)
        {
            Vector3 vector2 = gameObject.transform.position;
            float result= (vector2 - vector1).magnitude;
            Debug.ClearDeveloperConsole();
            Debug.Log($"Расстояние до объекта {gameObject.name} - {result}");

            distance = false;
        }
    }
}
