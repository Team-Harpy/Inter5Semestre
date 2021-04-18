using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoADM : Interactable
{
    public GameObject monstro;

    public override void Interact()
    {
        if (!monstro.activeInHierarchy)
            monstro.SetActive(true);
        else if (monstro.activeInHierarchy)
            monstro.SetActive(false);

        Destroy(gameObject);
    }
}
