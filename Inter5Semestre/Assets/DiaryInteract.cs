using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteract : Interactable
{
    public Diario diary;
    public GameObject atualizacao;
    public DialogueBase dialogo;
    public bool temDialogo;
    [SerializeField]
    private AudioClip[] desenharSons;
    public override void Interact()
    {
        diary.FillPage(atualizacao);
        diary.GetComponent<AudioSource>().clip = desenharSons[Random.Range(0, 2)];
        diary.GetComponent<AudioSource>().Play();
       if(temDialogo) DialogueManager.instance.EnqueueDialogue(dialogo);
    }
}
