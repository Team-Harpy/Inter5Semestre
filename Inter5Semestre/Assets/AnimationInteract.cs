using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteract : Interactable
{   [SerializeField]
    public Animator animator;
    [SerializeField]
    public string boolAnimationName;
    public override void Interact()
    {
        animator.SetBool(boolAnimationName, !animator.GetBool(boolAnimationName));
    }

    public void PlaySound()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
