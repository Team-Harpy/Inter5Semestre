using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarioInteract : Interactable
{
    public PopUpUI diary;

    public override void Interact()
    {
        diary.hasDiary = true;
        gameObject.SetActive(false);
    }
}
