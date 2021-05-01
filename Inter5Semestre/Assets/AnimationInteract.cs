using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteract : Interactable
{   [SerializeField]
    Animator animator;
    [SerializeField]
    string boolAnimationName;
    public override void Interact()
    {
        animator.SetBool(boolAnimationName, !animator.GetBool(boolAnimationName));
    }
}
