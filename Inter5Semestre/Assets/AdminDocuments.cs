using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AdminDocuments : Interactable
{
    [SerializeField]
    private CinemachineVirtualCamera lookVcamLeft;
    [SerializeField]
    private CinemachineVirtualCamera lookVcamRight;

    [SerializeField]
    GameObject document;
    [SerializeField]
    DialogueBase dialogo;
    [SerializeField]
    GameObject falasEscapar;

    [SerializeField]
    GameObject obstaculos;

    [SerializeField]
    GameObject monstro;
    [SerializeField]
    GameObject gas;

    [SerializeField]
    GameObject floatingDialogue;

    InputManager inputManager;

    LockCamera lockCamera;

    bool dialogoApareceu;
    [HideInInspector]
    public bool dialogoFlutua;

    [HideInInspector]
    public bool startCoroutine = true;

    private void Start()
    {
        inputManager = InputManager.Instance;
        lockCamera = GameObject.FindObjectOfType<LockCamera>();
    }

    private void Update()
    {
        if (dialogoApareceu && inputManager.NextDialogue())
        {
            dialogoApareceu = false;
        }
        if (dialogoFlutua)
        {
            if (!floatingDialogue.activeInHierarchy) dialogoFlutua = false;
        }
    }

    public override void Interact()
   {
        if(startCoroutine)StartCoroutine("LOL");
        if (!monstro.activeInHierarchy)
        {          
            obstaculos.SetActive(true);            
        }
     
    }

    IEnumerator LOL()
    {        
        startCoroutine = false;
        document.GetComponent<Animator>().SetTrigger("popUp");
        lockCamera.LockPlayerMovement();
        lockCamera.LockPlayerCamera();
        yield return new WaitForSeconds(1.5f);
        DialogueManager.instance.EnqueueDialogue(dialogo);
        dialogoApareceu = true;
        while (dialogoApareceu)
        {
            yield return null;
        }
        floatingDialogue.SetActive(true);
        dialogoFlutua = true;
        while (dialogoFlutua)
        {
            yield return null;
        }
        document.GetComponent<Animator>().SetTrigger("popUp");
        lookVcamLeft.Priority = 2;
        yield return new WaitForSeconds(3f);       
        lookVcamRight.Priority = 3;
        lookVcamLeft.Priority = 0;
        yield return new WaitForSeconds(3f);
        gas.SetActive(true);
        yield return new WaitForSeconds(2f);
        monstro.SetActive(true);      
        gas.SetActive(false);
        lookVcamRight.Priority = 0;
        falasEscapar.SetActive(true);
        lockCamera.UnlockPlayerMovement();
        lockCamera.UnlockPlayerCamera();




    }
   
}
