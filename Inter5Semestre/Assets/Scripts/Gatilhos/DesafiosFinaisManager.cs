using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DesafiosFinaisManager : MonoBehaviour
{
    //[HideInInspector]
    public int progressao = 0;
    [HideInInspector]
    public bool running = false;
    public Animator cadeado1;
    public Animator cadeado2;
    public Animator cadeado3;
    public Animator cadeado4;
    public CinemachineVirtualCamera cameraCadeados;

    [Header("Desafio Dep�sito")]
    public GameObject gatilhoDeposito;
    private bool iniciouD = false;

    [Header("Desafio Refeit�rio")]
    public GameObject gatilhoRefeitorio;
    private bool iniciouR = false;

    [Header("Desafio Vesti�rio")]
    private bool iniciouV = false;

    [Header("Desafio Lab B")]
    public Caixa objeto1;
    public Caixa objeto2;
    public Caixa objeto3;

    private void Update()
    {
        if (running)
        {
            if (!iniciouD)
            {
                gatilhoDeposito.SetActive(true);
                iniciouD = true;
            }

            if (!iniciouR)
            {
                gatilhoRefeitorio.SetActive(true);
                iniciouR = true;
            }

            objeto1.enabled = true;
            objeto2.enabled = true;
            objeto3.enabled = true;
        }

        if(progressao == 1)
        {
            //roda anima��o cadeado 1 caindo
            Debug.Log("Um");
        }
        else if (progressao == 2)
        {
            //roda anima��o cadeado 2 caindo
            Debug.Log("Dois");
        }
        else if (progressao == 3)
        {
            //roda anima��o cadeado 3 caindo
            Debug.Log("Tres");
        }
        else if (progressao == 4)
        {
            //roda anima��o cadeado 4 caindo
            Debug.Log("Quatro");
        }
    }
}
