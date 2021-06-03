using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MonstroADM : MonoBehaviour
{
    private Transform player;
    private RespawnManager respawnManager;
    [SerializeField]
    private float distanceToDie;
    private float distance;
    [SerializeField]
    private Volume stress;
    private float weightValue;
    public float velocidadeStress;
    public bool adm = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        
        if (distance <= distanceToDie + 0.2f) weightValue = 0.6f;
        else if (distance <= 2.5f) weightValue = 0.45f;
        else if (distance <= 5) weightValue = 0.3f;
        else if (distance <= 7.5f) weightValue = 0.15f;
        else if (distance <= 10) weightValue = 0;

        if(weightValue < stress.weight)
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
            if (adm)
            {
                respawnManager.RespawnADM();
            }
            else
            {
                respawnManager.RespawnSegundaFuga();
            }
        }
    }
}
