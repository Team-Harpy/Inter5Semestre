using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : Interactable
{
    public DialogueBase dialogoChave;
    public DialogueBase dialogoPortaTrancada;

    [SerializeField]
    private Diario diario;

    [SerializeField]
    private AudioClip chavePickupSound;
    [SerializeField]
    private GameObject quickSE;
   
    [SerializeField]
    private GameObject phone;

    [SerializeField]
    DialogueInteract doorToUnlock;

    public override void Interact()
    {
        DialogueManager.instance.EnqueueDialogue(dialogoChave);
        phone.GetComponent<TelefoneInteract>().hasKey = true;
        doorToUnlock.dialogo = dialogoPortaTrancada;
        quickSE.GetComponent<AudioSource>().clip = chavePickupSound;
        quickSE.GetComponent<AudioSource>().Play();
        diario.ConcludeSecondaryObjective("Entrar sala de segurança");
        gameObject.SetActive(false);
    }

    /*
     *  puzzleNormal.SetActive(true);
        puzzleSombra.SetActive(false);
        volumeManager.TransicaoOut(velocidadeTransicao);
        */

}
