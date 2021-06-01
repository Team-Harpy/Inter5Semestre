using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;

public class Macaneta : Interactable
{
    public CinemachineVirtualCamera lookAtHandle;
    public GameObject monstro;
    public DialogueBase dialogo;
    private BoxCollider bc;
    private PlayerController player;
    private VolumeManager volumeManager;
    public float velocidadeTransicao;
    public Diario diary;
    public GameObject atualizacaoMacaneta;
    public GameObject falasFuga;
    public GameObject dialogoADM;
    public GameObject obstaculos;
    public Volume stress;

    [Header("Textos")]
    public GameObject textosBox;
    public GameObject[] texto;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        volumeManager = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    public override void Interact()
    {
        StartCoroutine("SequenciaMacaneta");
    }

    IEnumerator SequenciaMacaneta()
    {
        player.interacting = true;
        falasFuga.SetActive(false);
        obstaculos.SetActive(false);
        bc.enabled = false;
        lookAtHandle.Priority = 2;
        monstro.SetActive(false);
        stress.weight = 0;
        yield return new WaitForSeconds(3f);

        textosBox.SetActive(true);
        texto[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        texto[1].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        texto[2].SetActive(true);
        yield return new WaitForSeconds(1.4f);
        texto[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        texto[4].SetActive(true);
        yield return new WaitForSeconds(0.8f);
        texto[5].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        texto[6].SetActive(true);
        yield return new WaitForSeconds(2.5f);

        DialogueManager.instance.EnqueueDialogue(dialogo);
        Destroy(textosBox);

        yield return new WaitForSeconds(1f);
        player.interacting = false;
        volumeManager.TransicaoOut(velocidadeTransicao);
        lookAtHandle.Priority = 0;
        diary.FillPage(atualizacaoMacaneta);
        dialogoADM.SetActive(true);
    }
}
