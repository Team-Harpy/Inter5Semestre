using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoLabA : Interactable
{
    public VolumeManager manager;
    public float velocidadeTransicao;
    public DialogueBase dialogo;
    public GameObject puzzleNormal;
    public GameObject puzzleSombra;

    public override void Interact()
    {
        puzzleNormal.SetActive(false);
        puzzleSombra.SetActive(true);
        manager.Transicao(velocidadeTransicao, dialogo);
        gameObject.SetActive(false);
    }
}
