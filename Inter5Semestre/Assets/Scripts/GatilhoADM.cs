using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoADM : Interactable
{
    public GameObject monstro;
    public GameObject obstaculo1;
    public GameObject obstaculo2;
    public GameObject obstaculo3;

    public override void Interact()
    {
        if (!monstro.activeInHierarchy)
        {
            monstro.SetActive(true);
            obstaculo1.SetActive(true);
            obstaculo2.SetActive(true);
            obstaculo3.SetActive(true);
        }
         
        else if (monstro.activeInHierarchy)
        {
            monstro.SetActive(false);
            obstaculo1.SetActive(false);
            obstaculo2.SetActive(false);
            obstaculo3.SetActive(false);
        }
           

        Destroy(gameObject);
    }
}
