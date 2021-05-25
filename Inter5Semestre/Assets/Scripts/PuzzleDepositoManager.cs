using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDepositoManager : MonoBehaviour
{
    [HideInInspector]
    public float progressao;

    private VolumeManager volume;
    public float velocidadeTransicao;

    public GameObject monstroOlho;
    public Animator portaDeposito;

    public Transform[] spawnPoints;
    [HideInInspector]
    public bool go;

    public GameObject[] objetivos;

    //sorteios
    private int sorteio;
    private int ultimoSorteio;

    private void Start()
    {
        progressao = 0;
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
        go = false;
    }

    private void Update()
    {
        if (go)
        {
            if (progressao == 1)
            {
                GatilhoInicial();
            }
            else if (progressao == 2)
            {
                SorteiaSpawn(objetivos[1]);
            }
            else if (progressao == 3)
            {
                SorteiaSpawn(objetivos[2]);
            }
            else if (progressao == 4)
            {
                Fim();
            }
        }
    }

    private void GatilhoInicial()
    {
        monstroOlho.SetActive(true);
        if (portaDeposito) portaDeposito.SetBool("Open", false);
        volume.Transicao(velocidadeTransicao);
        SorteiaSpawn(objetivos[0]);
        go = false;
    }

    private void SorteiaSpawn(GameObject objeto)
    {
        ultimoSorteio = sorteio;
        sorteio = Random.Range(0, spawnPoints.Length);
        if(sorteio == ultimoSorteio) sorteio = Random.Range(0, spawnPoints.Length);

        Instantiate(objeto, spawnPoints[sorteio].position, Quaternion.identity);
        go = false;
    }

    private void Fim()
    {
        volume.TransicaoOut(velocidadeTransicao);
        monstroOlho.SetActive(false);
        if (portaDeposito) portaDeposito.SetBool("Open", true);
        go = false;
    }
}
