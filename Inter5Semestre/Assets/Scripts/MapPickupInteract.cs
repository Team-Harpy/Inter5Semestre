using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickupInteract : Interactable
{
    public PopUpUI diary;
    [SerializeField]
    private DialogueBase mapaPickupDialogo;

    public override void Interact()
    {
        diary.hasMap = true;
        diary.OpenMapStart();
        gameObject.SetActive(false);
    }
}
