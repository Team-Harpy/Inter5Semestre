using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCaixasLabB : MonoBehaviour
{
    [HideInInspector]
    public bool caixaON;
    public Material errado;
    public Material certo;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            caixaON = true;
            render.sharedMaterial = certo;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            caixaON = false;
            render.sharedMaterial = errado;
        }
    }
}
