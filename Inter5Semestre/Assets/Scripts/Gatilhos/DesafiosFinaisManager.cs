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
    private bool finalizou1 = false;
    public Animator cadeado2;
    private bool finalizou2 = false;
    public Animator cadeado3;
    private bool finalizou3 = false;
    public Animator cadeado4;
    private bool finalizou4 = false;
    public CinemachineVirtualCamera cameraCadeados;

    [Header("Desafio Depósito")]
    public GameObject gatilhoDeposito;
    public GameObject caixasLabirinto;
    private bool iniciouD = false;

    [Header("Desafio Refeitório")]
    public GameObject gatilhoRefeitorio;
    private bool iniciouR = false;

    [Header("Desafio Vestiário")]
    private bool iniciouV = false;
    public VestiarioPuzzle vestiarioPuzzle;


    [Header("Desafio Lab B")]
    public Caixa objeto1;
    public Caixa objeto2;
    public Caixa objeto3;

    [Header("Telefonema")]
    public DialogueBase dialogo1;
    public AudioClip telefoneTocando;
    public BoxCollider telefone1;
    public BoxCollider telefone2;
    private AudioSource som;
    public DialogueBase dialogo2;
    public DialogueBase dialogo3;
    public DialogueBase dialogo4;

    private bool canCheat = false;

    private void Start()
    {
        som = telefone2.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (running)
        {
            if (!iniciouD)
            {
                gatilhoDeposito.SetActive(true);
                caixasLabirinto.SetActive(false);
                iniciouD = true;
            }

            if (!iniciouR)
            {
                gatilhoRefeitorio.SetActive(true);
                iniciouR = true;
            }

            if (!iniciouV)
            {
                vestiarioPuzzle.puzzleSetup = true;
                vestiarioPuzzle.GetComponent<BoxCollider>().enabled = true;
                iniciouV = true;
            }

            objeto1.enabled = true;
            objeto2.enabled = true;
            objeto3.enabled = true;

            canCheat = true;
        }

        if(progressao == 1)
        {
            if (!finalizou1)
            {
                StartCoroutine("DerrubaCadeado", cadeado1);
                finalizou1 = true;
            }
        }
        else if (progressao == 2)
        {
            if (!finalizou2)
            {
                StartCoroutine("DerrubaCadeado", cadeado2);
                finalizou2 = true;
            }
        }
        else if (progressao == 3)
        {
            if (!finalizou3)
            {
                StartCoroutine("DerrubaCadeado", cadeado3);
                finalizou3 = true;
            }
        }
        else if (progressao == 4)
        {
            if (!finalizou4)
            {
                StartCoroutine("DerrubaCadeado", cadeado4);
                StartCoroutine("Telefone");
                finalizou4 = true;
            }
        }

        if(canCheat && InputManager.Instance.Cheat())
        {
            progressao++;
        }
    }

    IEnumerator DerrubaCadeado(Animator anim)
    {
        cameraCadeados.Priority = 2;
        yield return new WaitForSeconds(1f);

        anim.SetTrigger("cai");
        yield return new WaitForSeconds(2f);

        cameraCadeados.Priority = 0;
    }

    IEnumerator Telefone()
    {
        yield return new WaitForSeconds(4f);

        DialogueManager.instance.EnqueueDialogue(dialogo1);
        yield return new WaitForSeconds(2f);

        telefone1.enabled = false;
        telefone2.enabled = true;
        som.clip = telefoneTocando;
        som.loop = true;
        som.Play();
        yield return new WaitForSeconds(5f);

        DialogueManager.instance.EnqueueDialogue(dialogo2);
        yield return new WaitForSeconds(10f);

        DialogueManager.instance.EnqueueDialogue(dialogo3);
        yield return new WaitForSeconds(10f);

        DialogueManager.instance.EnqueueDialogue(dialogo3);
    }
}
