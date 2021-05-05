using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPatrol : MonoBehaviour
{
    public GameObject pontoA;
    public GameObject pontoB;
    public float velocidade;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(pontoA.transform.localPosition, pontoB.transform.localPosition, velocidade * Time.deltaTime);
        if(transform.localPosition.z <= pontoB.transform.localPosition.z)
        {
            transform.localPosition = pontoA.transform.localPosition;
        }

        Debug.Log(pontoA.transform.position.z + ", "+ pontoB.transform.position.z + ", "+ transform.position.z);
    }
}
