using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GatilhoLabB : Interactable
{
    private PlayerController player;
    public CinemachineVirtualCamera lookAtDoorCorredorE;
    private BoxCollider bc;
    public GameObject blinking;
    private VolumeManager volume;
    public GameObject correntes;
    public DialogueBase dialogo;
    public DesafiosFinaisManager desafioFinal;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bc = GetComponent<BoxCollider>();
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    public override void Interact()
    {
        StartCoroutine("SequenciaPorta");
    }

    IEnumerator SequenciaPorta()
    {
        player.interacting = true;
        bc.enabled = false;
        lookAtDoorCorredorE.Priority = 2;
        yield return new WaitForSeconds(1f);

        blinking.SetActive(true);
        yield return new WaitForSeconds(5f);

        volume.Transicao(1);
        correntes.SetActive(true);
        lookAtDoorCorredorE.Priority = 0;
        player.interacting = false;
        desafioFinal.running = true;
        yield return new WaitForSeconds(3f);

        DialogueManager.instance.EnqueueDialogue(dialogo);
        gameObject.SetActive(false);
    }
}
