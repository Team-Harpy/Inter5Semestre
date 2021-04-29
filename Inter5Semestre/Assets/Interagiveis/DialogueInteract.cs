using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteract : Interactable
{
    public DialogueBase dialogo;
    [SerializeField]
    private bool runOnlyOnce;

    public override void Interact()
    {
        DialogueManager.instance.EnqueueDialogue(dialogo);
        if (runOnlyOnce)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
