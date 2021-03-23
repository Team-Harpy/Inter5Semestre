using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private GameObject pontoFinal;
    [SerializeField]
    private float velocidade;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pontoFinal.transform.position, velocidade * Time.deltaTime);
    }
}
