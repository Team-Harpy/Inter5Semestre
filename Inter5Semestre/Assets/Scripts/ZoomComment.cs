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

    [Header("Dialogo")]
    [SerializeField]
    private bool hasDialogue;
    [SerializeField]
    private DialogueBase dialogue;

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
        vcamZoom.Priority = 2;
        yield return new WaitForSeconds(1f);
        if (hasDialogue) DialogueManager.instance.EnqueueDialogue(dialogue);
        this.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        DialogueManager.instance.DequeueDialogue();
        vcamZoom.Priority = 0;

    }
}
