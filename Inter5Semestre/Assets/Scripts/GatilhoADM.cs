using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoADM : Interactable
{
    public GameObject monstro;
    public GameObject obstaculos;

    public override void Interact()
    {
        if (!monstro.activeInHierarchy)
        {
            monstro.SetActive(true);
            obstaculos.SetActive(true);
        }
         
        else if (monstro.activeInHierarchy)
        {
            monstro.SetActive(false);
            obstaculos.SetActive(false);
        }
           

        Destroy(gameObject);
    }
}
