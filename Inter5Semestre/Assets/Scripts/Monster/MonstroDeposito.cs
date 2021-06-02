using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class MonstroDeposito : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] pontosPatrol;
    public float delay;
    private float timer;

    private Transform player;
    private RespawnManager respawn;
    public float distanceToDie;
    private float distance;
    public Volume stress;
    public float velocidadeStress;
    private float weightValue;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(pontosPatrol[0].position);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        respawn = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
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

        distance = Vector3.Distance(transform.position, player.position);

        if (distance <= distanceToDie + 0.2f) weightValue = 1;
        else if (distance <= 2.5f) weightValue = 0.75f;
        else if (distance <= 5) weightValue = 0.5f;
        else if (distance <= 7.5f) weightValue = 0.25f;
        else if (distance <= 10) weightValue = 0;

        if (weightValue < stress.weight)
        {
            stress.weight -= velocidadeStress * Time.deltaTime;
            if (stress.weight < weightValue) stress.weight = weightValue;
        }
        if (weightValue > stress.weight)
        {
            stress.weight += velocidadeStress * Time.deltaTime;
            if (stress.weight > weightValue) stress.weight = weightValue;
        }

        if (distance <= distanceToDie)
        {
            Debug.Log("morreu");
            respawn.RespawnDeposito();
        }
    }

    private void SorteiaPonto()
    {
        int sorteio = Random.Range(0, pontosPatrol.Length);
        agent.SetDestination(pontosPatrol[sorteio].position);
    }
}
