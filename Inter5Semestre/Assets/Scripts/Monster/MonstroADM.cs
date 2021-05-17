using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroADM : MonoBehaviour
{
    private Transform player;
    private RespawnManager respawnManager;
    [SerializeField]
    private float distanceToDie;
    private float distance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        respawnManager = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if(distance <= distanceToDie)
        {
            respawnManager.Respawn1();
        }
    }
}
