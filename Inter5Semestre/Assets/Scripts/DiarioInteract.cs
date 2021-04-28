using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarioInteract : Interactable
{
    public Diario diary;

    public override void Interact()
    {
        diary.hasDiary = true;
        Destroy(gameObject);
    }
}
