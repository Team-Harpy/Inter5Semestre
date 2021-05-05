using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoADM : Interactable
{
    public GameObject monstro;
    public GameObject obstaculos;

    private VolumeManager volume;
    public float velocidadeTransicao;

    private void Start()
    {
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    public override void Interact()
    {
        if (!monstro.activeInHierarchy)
        {
            monstro.SetActive(true);
            obstaculos.SetActive(true);
            volume.Transicao(velocidadeTransicao);
        }
         
        else if (monstro.activeInHierarchy)
        {
            monstro.SetActive(false);
            obstaculos.SetActive(false);
            volume.TransicaoOut(velocidadeTransicao);
        }
           

        Destroy(gameObject);
    }
}
