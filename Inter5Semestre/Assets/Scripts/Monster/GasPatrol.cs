using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPatrol : MonoBehaviour
{
    public Transform alvo;
    public float velocidade;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
    }
}
