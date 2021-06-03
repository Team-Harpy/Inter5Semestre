using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SegundoTelefonema : Interactable
{
    private PlayerController player;
    public DesafiosFinaisManager desafioFinal;
    private BoxCollider bc;
    private AudioSource som;
    public AudioClip telefoneCaindo;
    public DialogueBase dialogo;
    private bool conta = false;
    private int dialogoNumeracao = 1;
    public int dialogoPause1;
    public int dialogoPause2;
    public CinemachineVirtualCamera lookAtPhone;
    public CinemachineVirtualCamera lookAtShadow;
    public GameObject sombra;
    public GameObject gas;
    private MonsterAI sombraNav;
    public int dialogoFim;
    public GameObject obstaculo;
    public DialogueBase falaMonstro1;
    public DialogueBase falaMonstro2;
    public DialogueBase falaMonstro3;
    public DialogueBase falaMonstro4;
    public DialogueBase falaMonstro5;
    public DialogueBase falaMonstro6;
    public GameObject correntes;
    public GameObject portaRecep;
    private Animator portaRecepAnim;
    public GameObject portaRecepAbrePorTras;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bc = GetComponent<BoxCollider>();
        som = GetComponent<AudioSource>();

        sombraNav = sombra.GetComponent<MonsterAI>();

        portaRecepAnim = portaRecep.GetComponent<Animator>();
    }

    private void Update()
    {
        if (InputManager.Instance.NextDialogue() && conta) dialogoNumeracao++;
    }

    public override void Interact()
    {
        conta = true;
        desafioFinal.StopAllCoroutines();
        StartCoroutine("Telefonema");
    }

    IEnumerator Telefonema()
    {
        player.interacting = true;
        lookAtPhone.Priority = 2;
        som.Stop();
        bc.enabled = false;
        DialogueManager.instance.EnqueueDialogue(dialogo);

        Destroy(portaRecep.GetComponent<DialogueInteract>());
        portaRecep.AddComponent<AnimationInteract>();
        portaRecep.GetComponent<AnimationInteract>().animator = portaRecepAnim;
        portaRecep.GetComponent<AnimationInteract>().boolAnimationName = "Open";
        portaRecepAbrePorTras.SetActive(false);

        while (dialogoNumeracao < dialogoPause1)
        {
            yield return null;
        }
        som.PlayOneShot(telefoneCaindo);

        while (dialogoNumeracao < dialogoPause2)
        {
            yield return null;
        }
        sombra.SetActive(true);
        lookAtShadow.Priority = 3;
        lookAtPhone.Priority = 0;

        while (dialogoNumeracao < dialogoFim)
        {
            yield return null;
        }
        lookAtShadow.Priority = 0;
        player.interacting = false;
        sombraNav.enabled = true;
        gas.SetActive(true);
        obstaculo.SetActive(true);
        correntes.SetActive(false);

        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(falaMonstro1);
        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(falaMonstro2);
        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(falaMonstro3);
        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(falaMonstro4);
        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(falaMonstro5);
        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(falaMonstro6);
    }
}
