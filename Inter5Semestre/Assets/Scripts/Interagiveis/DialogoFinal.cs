using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoFinal : Interactable
{
    public DialogueBase dialogoFinal;
    private bool conta;
    private int dialogoNumeracao = 1;
    public int numeroFalas;
    private BoxCollider bc;
    public BoxCollider botao;
    private RespawnManager respawn;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        respawn = GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<RespawnManager>();
    }

    private void Update()
    {
        if (InputManager.Instance.NextDialogue() && conta) dialogoNumeracao++;

        if (dialogoNumeracao > numeroFalas)
        {
            botao.enabled = true;
            this.enabled = false;
        }
    }

    public override void Interact()
    {
        respawn.StopAllCoroutines();
        conta = true;
        bc.enabled = false;
        DialogueManager.instance.EnqueueDialogue(dialogoFinal);
    }
}
