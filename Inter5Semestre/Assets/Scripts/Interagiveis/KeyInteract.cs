using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : Interactable
{
    public DialogueBase dialogoChave;
    public DialogueBase dialogoTelefone;

    [SerializeField]
    private GameObject phone;

    [SerializeField]
    GameObject doorToUnlock;

    [SerializeField]
    Animator animator;
    [SerializeField]
    string boolName;

    private VolumeManager volumeManager;
    [SerializeField]
    private float velocidadeTransicao;
    [SerializeField]
    private GameObject puzzleNormal;
    [SerializeField]
    private GameObject puzzleSombra;

    private void Start()
    {
        volumeManager = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    public override void Interact()
    {
        DialogueManager.instance.EnqueueDialogue(dialogoChave);
        phone.GetComponent<DiaryInteract>().temDialogo = true;
        phone.GetComponent<DiaryInteract>().dialogo = dialogoTelefone;
        Destroy(doorToUnlock.GetComponent<DialogueInteract>());
        doorToUnlock.AddComponent<AnimationInteract>();
        animator = doorToUnlock.GetComponent<Animator>();
        doorToUnlock.GetComponent<AnimationInteract>().animator = this.animator;
        doorToUnlock.GetComponent<AnimationInteract>().boolAnimationName = boolName;
        gameObject.SetActive(false);
    }

    /*
     *  puzzleNormal.SetActive(true);
        puzzleSombra.SetActive(false);
        volumeManager.TransicaoOut(velocidadeTransicao);
        */

}
