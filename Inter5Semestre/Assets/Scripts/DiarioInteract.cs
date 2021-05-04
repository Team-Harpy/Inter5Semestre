using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarioInteract : Interactable
{
    public PopUpUI diary;
    public DialogueBase falaDiario;
  
    bool diarioAberto;
    bool coroutineStart = true;

    private void Update()
    {
        if (!diary.diaryOpened && !coroutineStart)
        {
            diarioAberto = false;
        }
    }

    public override void Interact()
    {
        StartCoroutine("DiarioPickupMiniEvent");
       
    }

    IEnumerator DiarioPickupMiniEvent()
    {
        coroutineStart = false;
        diarioAberto = true;
        diary.hasDiary = true;
        diary.OpenDiaryStart();
        while (diarioAberto)
        {
            yield return null;
        }
        DialogueManager.instance.EnqueueDialogue(falaDiario);
        this.gameObject.SetActive(false);
    }
}
