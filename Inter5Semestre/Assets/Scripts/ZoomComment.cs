using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomComment : Interactable
{
    // Start is called before the first frame update
   
    private bool coroutineStart = true;
    
    [SerializeField]
    private Diario diario;

    InputManager inputManager;
    [SerializeField]
    private GameObject flashlight;
    private bool goBack;

    [Header("Dialogo")]
    [SerializeField]
    private bool hasDialogue;
    [SerializeField]
    private DialogueBase dialogue;
    [SerializeField]
    private bool runOnlyOnce;

    [Header("Objetivo")]
    [SerializeField]
    private bool hasSecondaryObjective;
    [SerializeField]
    private string secondaryObjectiveName;


    [Header("Diario")]
    [SerializeField]
    private bool hasDiaryUpdate;
    [SerializeField]
    private GameObject update;


    [Header("CameraTransition")]
    [SerializeField]
    private CinemachineVirtualCamera vcamNormal;
    [SerializeField]
    private CinemachineVirtualCamera vcamZoom;
    
    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.NextDialogue() && !coroutineStart) goBack = true;
    }
    public override void Interact()
    {
        //Objetivo
        if(hasSecondaryObjective) diario.AddSecondaryObjective(secondaryObjectiveName);

        //Diario
        if (hasDiaryUpdate) diario.FillPage(update);

       
        
              
       
       if(coroutineStart) StartCoroutine("ZoomPlusComment");
                              
    }


    IEnumerator ZoomPlusComment()
    {
        coroutineStart = false;
        flashlight.SetActive(false);
        vcamZoom.Priority = 2;
        yield return new WaitForSeconds(1f);
        if (hasDialogue) DialogueManager.instance.EnqueueDialogue(dialogue);
        this.GetComponent<BoxCollider>().enabled = false;
        while (!goBack)
        {
            yield return null;
        }
        DialogueManager.instance.DequeueDialogue();
        vcamZoom.Priority = 0;
        yield return new WaitForSeconds(1f);
        flashlight.SetActive(true);
        if (runOnlyOnce)
        {
            gameObject.GetComponent<ZoomComment>().enabled = false;
        }

    }
}
