using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelefoneInteract : Interactable
{
    public bool hasKey;
    public Diario diary;
    public GameObject atualizacaoSemChave;
    public GameObject atualizacaoComChave;
    public DialogueBase dialogo;
    private bool coroutineStart = true;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip telefoneCaindo;

    private int dialogoNumeracao = 1;

    InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (inputManager.NextDialogue()) dialogoNumeracao += 1;
    }
    public override void Interact()
    {
        if (!hasKey)
        {
            diary.FillPage(atualizacaoSemChave);
        }

        else
        {
            if (coroutineStart) StartCoroutine("EventoTelefone");
        }
    }


    IEnumerator EventoTelefone()
    {
        coroutineStart = false;
        audioSource.Stop();      
        DialogueManager.instance.EnqueueDialogue(dialogo);
        while (dialogoNumeracao < 5)
        {
            yield return null;
        }
        audioSource.clip = telefoneCaindo;
        audioSource.Play();
        yield return new WaitForSeconds(2.7f);
        audioSource.Stop();
        diary.FillPage(atualizacaoComChave);

    }
}
