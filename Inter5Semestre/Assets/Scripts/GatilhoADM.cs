using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GatilhoADM : Interactable
{
    public GameObject monstro;
    public GameObject obstaculos;

    private VolumeManager volume;
    public float velocidadeTransicao;
    [SerializeField]
    private GameObject falasFlutuantes;

    public Volume stress;

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
            stress.weight = 0;
            falasFlutuantes.SetActive(false);
        }
           

        Destroy(gameObject);
    }
}
