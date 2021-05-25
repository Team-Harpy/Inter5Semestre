using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoDeposito : Interactable
{
    private PuzzleDepositoManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("DepositoManager").GetComponent<PuzzleDepositoManager>();
    }

    public override void Interact()
    {
        manager.progressao += 1;
        manager.go = true;
        gameObject.SetActive(false);
    }
}
