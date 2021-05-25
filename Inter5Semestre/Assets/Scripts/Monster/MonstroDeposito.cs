using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstroDeposito : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] pontosPatrol;
    public float delay;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(pontosPatrol[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.5f)
        {
            timer += Time.deltaTime;
            if(timer >= delay)
            {
                SorteiaPonto();
                timer = 0;
            }
        }
    }

    private void SorteiaPonto()
    {
        int sorteio = Random.Range(0, pontosPatrol.Length);
        agent.SetDestination(pontosPatrol[sorteio].position);
    }
}
