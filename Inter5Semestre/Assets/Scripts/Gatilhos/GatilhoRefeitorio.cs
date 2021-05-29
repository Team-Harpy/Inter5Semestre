using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoRefeitorio : Interactable
{
    private VolumeManager volume;
    public float velocidadeTransicao;
    public GameObject sombras;
    public GameObject grades;
    public GameObject gas;
    public GameObject objetoFinal;
    public bool final = false;

    private void Start()
    {
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }
    public override void Interact()
    {
        if (!final)
        {
            volume.Transicao(velocidadeTransicao);
            sombras.SetActive(true);
            grades.SetActive(true);
            gas.SetActive(true);
            if (objetoFinal) objetoFinal.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (final)
        {
            volume.TransicaoOut(velocidadeTransicao);
            sombras.SetActive(false);
            grades.SetActive(false);
            gas.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
