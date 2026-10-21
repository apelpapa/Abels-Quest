using System;
using UnityEngine;
using UnityEngine.AI;



public class PlayerMover : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = target.position;
    }
}