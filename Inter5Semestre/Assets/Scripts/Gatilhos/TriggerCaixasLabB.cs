using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCaixasLabB : MonoBehaviour
{
    [HideInInspector]
    public bool caixaON;
    public Material errado;
    public Material certo;
    public ParticleSystem particula;
    public Color vermelho;
    public Color verde;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
        var main = particula.main;
        main.startColor = vermelho;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            caixaON = true;
            render.sharedMaterial = certo;
            var main = particula.main;
            main.startColor = verde;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            caixaON = false;
            render.sharedMaterial = errado;
            var main = particula.main;
            main.startColor = vermelho;
        }
    }
}
