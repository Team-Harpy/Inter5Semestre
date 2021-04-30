using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteract : Interactable
{
    public Diario diary;
    public GameObject atualizacao;
    public DialogueBase dialogo;
    public override void Interact()
    {
        diary.FillPage(atualizacao);
        DialogueManager.instance.EnqueueDialogue(dialogo);
    }
}
