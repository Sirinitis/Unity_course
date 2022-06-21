using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float speed;

    private void CalculationVictims()
    {
        Destroy(gameObject);
        foreach(GameObject item in FireZone.victim)
        {
            Vector3 _force = (item.transform.position - transform.position).normalized;
            item.GetComponent<Rigidbody>().AddForceAtPosition(_force * speed, transform.position, ForceMode.Impulse);  
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        CalculationVictims();
        Debug.Log(collision.gameObject.name + " активировал бомбу!"); 
    }
}
