using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteract : Interactable
{
    public Diario diary;
    public GameObject atualizacao;
    public DialogueBase dialogo;
    public bool temDialogo;
    bool once;
    
    public override void Interact()
    {
        if (!once)
        {
            diary.FillPage(atualizacao);
            if (temDialogo) DialogueManager.instance.EnqueueDialogue(dialogo);
            once = true;
        }
      
    }
}
