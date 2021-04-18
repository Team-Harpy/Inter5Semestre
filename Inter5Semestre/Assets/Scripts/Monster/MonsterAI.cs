using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;


    private void Update()
    {
        agent.SetDestination(FindObjectOfType<PlayerController>().transform.position);
    }
}
