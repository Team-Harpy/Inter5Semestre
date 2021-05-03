using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaDeposito : Interactable
{
    public GameObject portaPai;

    public override void Interact()
    {
        portaPai.SetActive(false);        
    }
}
