using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class RespawnManager : MonoBehaviour
{
    private GameObject player;
    private GameObject myCam;
    private VolumeManager volume;
    public Volume stress;

    [Header("Respawn ADM")]
    public Transform respawnPoint1;
    public Animator portaADM;
    public GameObject monstro1;
    private Vector3 monstroPosI;
    public GameObject falasFlutuantes;
    public GameObject obstaculos;
    public AdminDocuments doc;

    [Header("Respawn Deposito")]
    public Transform respawnPointDeposito;
    public GameObject monstroOlho;
    private Vector3 monstroOlhoPosI;
    public GameObject portaDeposito;
    public GameObject trancaDeposito;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCam = GameObject.FindGameObjectWithTag("MainCamera");
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();

        monstroPosI = monstro1.transform.position;

        monstroOlhoPosI = monstroOlho.transform.position;
    }

    public void RespawnADM()
    {
        player.transform.position = respawnPoint1.position;
        myCam.transform.rotation = respawnPoint1.rotation;
        portaADM.SetBool("Open", false);
        monstro1.transform.position = monstroPosI;
        monstro1.SetActive(false);
        monstro1.GetComponent<NavMeshAgent>().speed = 0.2f;
        falasFlutuantes.SetActive(false);
        obstaculos.SetActive(false);
        doc.startCoroutine = true;
        stress.weight = 0;
        volume.TransicaoOut(1);
    }

    public void RespawnDeposito()
    {
        player.transform.position = respawnPointDeposito.position;
        myCam.transform.rotation = respawnPointDeposito.rotation;
        monstroOlho.SetActive(false);
        monstroOlho.transform.position = monstroOlhoPosI;
        if (portaDeposito)
        {
            portaDeposito.GetComponent<BoxCollider>().enabled = true;
        }
        trancaDeposito.SetActive(false);
        stress.weight = 0;
        volume.TransicaoOut(1);
    }
}
