using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class BotaoFinal : Interactable
{
    public Diario diary;
    public GameObject atualizacaoFinal1;
    public GameObject atualizacaoFinal2;
    public GameObject atualizacaoFinal3;
    public DialogueBase dialogo;
    private BoxCollider bc;
    public int cenaACarregar;

    public Volume stress;
    public float velocidadeTransicao;
    public PopUpUI popUp;

    private bool transiciona = false;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    public override void Interact()
    {
        bc.enabled = false;
        DialogueManager.instance.EnqueueDialogue(dialogo);
        transiciona = true;
        StartCoroutine("Final");
    }

    private void Update()
    {
        if (transiciona)
        {
            stress.weight += velocidadeTransicao * Time.deltaTime;
            if (stress.weight >= 0.95f) stress.weight = 0.95f;
        }
    }

    public void CarregaCena()
    {
        SceneManager.LoadScene(cenaACarregar);
    }

    IEnumerator Final()
    {
        while(stress.weight < 0.95f)
        {
            yield return null;
        }

        diary.FillPage(atualizacaoFinal1);
        diary.FillPage(atualizacaoFinal2);
        diary.FillPage(atualizacaoFinal3);

        popUp.OpenDiary();
        popUp.lockDiary = true;
    }
}
