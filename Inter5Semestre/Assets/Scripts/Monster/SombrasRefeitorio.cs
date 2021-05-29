using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombrasRefeitorio : MonoBehaviour
{
    private SpriteRenderer sr;
    private Transform player;
    public float minDistance;
    private float alphaValue;
    public float velocidade;
    private RespawnManager respawn;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        respawn = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance < minDistance)
        {
            alphaValue += velocidade * Time.deltaTime;
            if (alphaValue >= 1) alphaValue = 1;
        }
        else if(distance > minDistance)
        {
            alphaValue -= velocidade * Time.deltaTime;
            if (alphaValue <= 0) alphaValue = 0;
        }

        if(distance <= 0.5)
        {
            respawn.RespawnRefeitorio();
        }

        sr.color = new Color(1, 1, 1, alphaValue);
    }
}
