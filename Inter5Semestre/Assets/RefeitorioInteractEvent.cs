using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefeitorioInteractEvent : Interactable
{
    [SerializeField]
    private Diario diario;

    [SerializeField]
    private GameObject efeitoVisual;

    private bool coroutineStart;

    [SerializeField]
    private DialogueBase dialogue;


    [SerializeField]
    private GameObject update;
    // Start is called before the first frame update
    public override void Interact()
    {
       if(!coroutineStart) StartCoroutine("RefeitorioEvent");
        coroutineStart = true;
    }


    IEnumerator RefeitorioEvent()
    {
        efeitoVisual.SetActive(true);
        yield return new WaitForSeconds(1f);
        DialogueManager.instance.EnqueueDialogue(dialogue);
        yield return new WaitForSeconds(5f);
        efeitoVisual.GetComponent<Animator>().SetBool("fadeOut", true);
        yield return new WaitForSeconds(1f);
        efeitoVisual.SetActive(false);
        diario.FillPage(update);
    }
   
}
