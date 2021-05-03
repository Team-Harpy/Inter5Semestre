using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : Interactable
{
    public BoxCollider portaPai;
    public GameObject portaFilho;


    public override void Interact()
    {
        portaFilho.SetActive(true);
        portaPai.enabled = false;
        gameObject.SetActive(false);
    }
}
