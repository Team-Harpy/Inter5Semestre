using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Diario : MonoBehaviour
{
    InputManager inputManager;

    private bool firstPage = true;

    [SerializeField]
    private AudioClip[] desenharSons;


    [SerializeField]
    GameObject objectivesPage;

    [SerializeField]
    private TMP_Text[] objetivosSecundarios;
    private int objetivoSecundarioIndex;

    private GameObject novaAnotacaoAdicionada;
    private GameObject novoObjetivoAdicionado;

    [SerializeField]
    private GameObject newPageSet;

    [SerializeField]
    private List<GameObject> pages = new List<GameObject>();

    
    private int currentPage; // 1 = 1/2 ; 3 = 3/4 ...

   
    private bool leftPageFilled;
   
    private bool bothPagesFilled;

    private AudioSource audiosource;
   
    private GameObject lastUpdate, lastUpdate2;


    [SerializeField]
    private Transform leftPosition, rightPosition;

    [SerializeField]
    GameObject anotacaoNeta;

    private void Start()
    {
        inputManager = InputManager.Instance;
        currentPage = 0;
        pages.Add(objectivesPage);
        bothPagesFilled = true;
        novaAnotacaoAdicionada = GameObject.Find("NovaAnotacaoAdicionada");
        novoObjetivoAdicionado = GameObject.Find("NovoObjetivoAdicionado");
        novoObjetivoAdicionado.SetActive(false);
        novaAnotacaoAdicionada.SetActive(false);
        audiosource = GetComponent<AudioSource>();
        FillPage(anotacaoNeta);
        PreviousPage();
    }


    public void AddPrimaryObjective()
    {

    }
    public void AddSecondaryObjective(string nomeObjetivo)
    {
        objetivosSecundarios[objetivoSecundarioIndex].text = nomeObjetivo;
        objetivoSecundarioIndex += 1;
        novoObjetivoAdicionado.SetActive(true);
        PlaySound();

    }

    public void ConcludeSecondaryObjective(string nomeObjetivo)
    {
        for (int i = 0; i < objetivosSecundarios.Length; i++)
        {
            if(nomeObjetivo == objetivosSecundarios[i].text)
            {
                objetivosSecundarios[i].fontStyle = FontStyles.Strikethrough;
                return;
            }
        }
    }



    public void FillPage(GameObject atualizacao)
    {
        if (bothPagesFilled)
        {
            pages[currentPage].SetActive(false);
            currentPage = pages.Count;
            bothPagesFilled = false;
            leftPageFilled = false;
            firstPage = false;


        }

        if (!leftPageFilled)
        {
            newPageSet = new GameObject("Page" + currentPage);
            newPageSet.transform.parent = this.gameObject.transform;
            pages.Add(newPageSet);
            atualizacao.transform.position = leftPosition.position;
            atualizacao.transform.parent = newPageSet.transform;
            leftPageFilled = true;

        }
        else
        {
            atualizacao.transform.parent = newPageSet.transform;
            atualizacao.transform.position = rightPosition.position;
            bothPagesFilled = true;
        }
        if (lastUpdate != null) lastUpdate2 = lastUpdate;

        lastUpdate = atualizacao;
        novaAnotacaoAdicionada.SetActive(true);
        PlaySound();
        


    }



    void PlaySound()
    {
        audiosource.clip = desenharSons[Random.Range(0, 3)];
        audiosource.Play();
    }


    public void NextPage()
    {
        if (currentPage + 1 >= pages.Count)
        {
            return;
        }

        else
        {
            pages[currentPage].SetActive(false);
            pages[currentPage + 1].SetActive(true);
            currentPage += 1;

        }

    }


   

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            pages[currentPage].SetActive(false);
            pages[currentPage - 1].SetActive(true);
            currentPage -= 1;
        }
    }
}
