using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInteract : Interactable
{
    [SerializeField]
    GameObject doorToUnlock;

    [SerializeField]
    DialogueBase dialogo;

    [SerializeField]
    Animator animator;
    [SerializeField]
    string boolName;


    public override void Interact()
    {
        Destroy(doorToUnlock.GetComponent<DialogueInteract>());
        doorToUnlock.AddComponent<AnimationInteract>();
        animator = doorToUnlock.GetComponent<Animator>();
        doorToUnlock.GetComponent<AnimationInteract>().animator = this.animator;
        doorToUnlock.GetComponent<AnimationInteract>().boolAnimationName = boolName;
        Destroy(this.gameObject);
        DialogueManager.instance.EnqueueDialogue(dialogo);
    }

}
