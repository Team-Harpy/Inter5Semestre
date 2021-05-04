using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickupInteract : Interactable
{
    public PopUpUI diary;

    public override void Interact()
    {
        diary.hasMap = true;
        gameObject.SetActive(false);
    }
}
