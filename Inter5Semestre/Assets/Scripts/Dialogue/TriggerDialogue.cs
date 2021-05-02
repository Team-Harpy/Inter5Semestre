using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public DialogueBase dialogue;
    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    /*private void Update()
    {
        if (inputManager.Interact())
        {
            Trigger();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trigger();
        }
    }

    public void Trigger()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
        gameObject.SetActive(false);
    }
}
