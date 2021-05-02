using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GatilhoLabA : Interactable
{
    public Volume real;
    public Volume alucinacao;

    public override void Interact()
    {
        real.priority = 0;
        alucinacao.priority = 1;
        gameObject.SetActive(false);
    }
}
