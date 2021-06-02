using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoFinal : Interactable
{
    public Diario diary;
    public GameObject atualizacaoFinal1;
    public GameObject atualizacaoFinal2;
    public GameObject atualizacaoFinal3;
    public DialogueBase dialogo;
    private BoxCollider bc;
    public int cenaACarregar;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    public override void Interact()
    {

        bc.enabled = false;
        DialogueManager.instance.EnqueueDialogue(dialogo);
        diary.FillPage(atualizacaoFinal1);
        diary.FillPage(atualizacaoFinal2);
        diary.FillPage(atualizacaoFinal3);
    }

    public void CarregaCena()
    {
        SceneManager.LoadScene(cenaACarregar);
    }
}
