using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RespawnManager : MonoBehaviour
{
    private GameObject player;
    private GameObject camera;
    private VolumeManager volume;

    [Header("Respawn 1")]
    public Transform respawnPoint1;
    public Animator portaADM;
    public GameObject monstro1;
    private Vector3 monstroPosI;
    public GameObject falasFlutuantes;
    public GameObject obstaculos;
    public AdminDocuments doc;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();

        monstroPosI = monstro1.transform.position;
    }

    public void Respawn1()
    {
        player.transform.position = respawnPoint1.position;
        camera.transform.rotation = respawnPoint1.rotation;
        portaADM.SetBool("Open", false);
        monstro1.transform.position = monstroPosI;
        monstro1.SetActive(false);
        monstro1.GetComponent<NavMeshAgent>().speed = 0.2f;
        falasFlutuantes.SetActive(false);
        obstaculos.SetActive(false);
        doc.startCoroutine = true;
        volume.TransicaoOut(1);
    }
}
