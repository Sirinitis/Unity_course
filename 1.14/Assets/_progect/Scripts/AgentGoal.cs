using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentGoal : MonoBehaviour
{
    [SerializeField] private Transform _goalTransform;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination = _goalTransform.position;
    }
}
