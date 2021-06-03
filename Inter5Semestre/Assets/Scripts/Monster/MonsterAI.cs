using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    public float velocidade1;
    public float velocidade2;
    private Transform player;
    public float distanceToChange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void Update()
    {
        agent.SetDestination(FindObjectOfType<PlayerController>().transform.position);

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > distanceToChange)
        {
            agent.speed = velocidade2;
        }
        else if (distance <= distanceToChange)
        {
            agent.speed = velocidade1;
        }
    }
}
