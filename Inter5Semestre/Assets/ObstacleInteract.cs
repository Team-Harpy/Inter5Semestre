using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInteract : Interactable
{
    [SerializeField]
    GameObject doorToUnlock;
    [SerializeField]
    GameObject doorToUnlock2;

    [SerializeField]
    DialogueBase dialogo;

    [SerializeField]
    Animator animator;
    [SerializeField]
    Animator animator2;
    [SerializeField]
    string boolName;


    public override void Interact()
    {
        Destroy(doorToUnlock.GetComponent<DialogueInteract>());
        doorToUnlock.AddComponent<AnimationInteract>();
        animator = doorToUnlock.GetComponent<Animator>();
        doorToUnlock.GetComponent<AnimationInteract>().animator = this.animator;
        doorToUnlock.GetComponent<AnimationInteract>().boolAnimationName = boolName;
        if (doorToUnlock2 && animator2)
        {
            Destroy(doorToUnlock2.GetComponent<DialogueInteract>());
            doorToUnlock2.AddComponent<AnimationInteract>();
            animator2 = doorToUnlock2.GetComponent<Animator>();
            doorToUnlock2.GetComponent<AnimationInteract>().animator = this.animator2;
            doorToUnlock2.GetComponent<AnimationInteract>().boolAnimationName = boolName;
        }
        gameObject.SetActive(false);
        if (dialogo) DialogueManager.instance.EnqueueDialogue(dialogo);
    }

}
