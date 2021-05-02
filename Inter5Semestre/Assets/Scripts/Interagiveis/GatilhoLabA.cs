using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoLabA : Interactable
{
    public VolumeManager manager;
    public float velocidadeTransicao;
    public DialogueBase dialogo;

    public override void Interact()
    {
        manager.Transicao(velocidadeTransicao, dialogo);
        gameObject.SetActive(false);
    }
}
