using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCaixasLabB : MonoBehaviour
{
    [HideInInspector]
    public bool caixaON;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            caixaON = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            caixaON = false;
        }
    }
}
