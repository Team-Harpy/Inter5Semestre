using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : Interactable
{
    public DialogueBase dialogoChave;
    public DialogueBase dialogoPortaTrancada;
   
    [SerializeField]
    private GameObject phone;

    [SerializeField]
    DialogueInteract doorToUnlock;

    public override void Interact()
    {
        DialogueManager.instance.EnqueueDialogue(dialogoChave);
        phone.GetComponent<TelefoneInteract>().hasKey = true;
        doorToUnlock.dialogo = dialogoPortaTrancada;
        gameObject.SetActive(false);
    }

    /*
     *  puzzleNormal.SetActive(true);
        puzzleSombra.SetActive(false);
        volumeManager.TransicaoOut(velocidadeTransicao);
        */

}
