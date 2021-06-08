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

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
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
        conta = true;
        bc.enabled = false;
        DialogueManager.instance.EnqueueDialogue(dialogoFinal);
    }
}
