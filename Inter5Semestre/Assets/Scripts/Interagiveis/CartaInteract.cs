using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaInteract : Interactable
{
    public GameObject carta;
    private InputManager input;
    private BoxCollider bc;
    public bool runOnlyOnce;
    public DialogueBase dialogo;
    public Diario diary;
    public GameObject atualizacaoDiario;
    private bool interagindo = false;
    private PlayerController player;
    private LockCamera lockCamera;

    private void Start()
    {
        input = InputManager.Instance;
        bc = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lockCamera = GameObject.FindGameObjectWithTag("LockCamera").GetComponent<LockCamera>();
    }

    public override void Interact()
    {
        carta.SetActive(true);
        lockCamera.LockPlayerCamera();
        player.interacting = true;
        interagindo = true;

        if (runOnlyOnce)
        {
            bc.enabled = false;
        }
    }

    private void Update()
    {
        if (input.ExitLock() && interagindo)
        {
            if(dialogo) DialogueManager.instance.EnqueueDialogue(dialogo);
            if (atualizacaoDiario) diary.FillPage(atualizacaoDiario);
            player.interacting = false;
            lockCamera.UnlockPlayerCamera();
            interagindo = false;
            carta.SetActive(false);
        }
    }
}
