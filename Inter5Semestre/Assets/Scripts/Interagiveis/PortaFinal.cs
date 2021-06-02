using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortaFinal : Interactable
{
    public SegundoTelefonema telefonema2;
    public Animator porta;
    public DialogueBase dialogo;
    public GameObject monstro;
    public Volume stress;
    private bool first = false;

    public override void Interact()
    {
        if (!first)
        {
            telefonema2.StopAllCoroutines();
            DialogueManager.instance.EnqueueDialogue(dialogo);
            monstro.SetActive(false);
            stress.weight = 0;
            first = true;
            porta.SetBool("Open", true);
        }
    }
}
