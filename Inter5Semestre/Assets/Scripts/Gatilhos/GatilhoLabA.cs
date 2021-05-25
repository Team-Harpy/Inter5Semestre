using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoLabA : Interactable
{
    private VolumeManager manager;
    public float velocidadeTransicao;
    public DialogueBase dialogo;
    public GameObject puzzleNormal;
    public GameObject puzzleSombra;
    public GameObject cctvCamera;

    [SerializeField]
    private AudioSource quickSE;
    [SerializeField]
    private AudioClip heavyBreathing;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    public override void Interact()
    {
        puzzleNormal.SetActive(false);
        cctvCamera.SetActive(true);
        puzzleSombra.SetActive(true);
        manager.Transicao(velocidadeTransicao, dialogo);
        quickSE.clip = heavyBreathing;
        quickSE.Play();
        gameObject.SetActive(false);
    }
}
