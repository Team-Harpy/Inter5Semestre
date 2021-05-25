using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoDeposito : Interactable
{
    private PuzzleDepositoManager manager;
    public bool destroyOnReset;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("DepositoManager").GetComponent<PuzzleDepositoManager>();
    }

    private void Update()
    {
        if (destroyOnReset && manager.progressao == 0) Destroy(gameObject);
    }

    public override void Interact()
    {
        manager.progressao += 1;
        manager.go = true;
        gameObject.SetActive(false);
    }
}
