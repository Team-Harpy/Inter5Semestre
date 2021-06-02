using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefeitorioInteractEvent : Interactable
{
    [SerializeField]
    private Diario diario;

    private InputManager inputManager;
    private bool goBack;

    [SerializeField]
    private GameObject efeitoVisual;

    private bool coroutineStart = true;

    [SerializeField]
    private DialogueBase dialogue;


    [SerializeField]
    private GameObject update;
    // Start is called before the first frame update


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
       if(coroutineStart) StartCoroutine("RefeitorioEvent");
      
    }


    IEnumerator RefeitorioEvent()
    {
        coroutineStart = false;
        efeitoVisual.SetActive(true);
        yield return new WaitForSeconds(1f);
        DialogueManager.instance.EnqueueDialogue(dialogue);
        while (!goBack)
        {
            yield return null;
        }
        efeitoVisual.GetComponent<Animator>().SetBool("fadeOut", true);
        yield return new WaitForSeconds(1f);
        efeitoVisual.SetActive(false);
        diario.FillPage(update);
    }
   
}
