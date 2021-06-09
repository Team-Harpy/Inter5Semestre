using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefeitorioFinal : MonoBehaviour
{
    public Diario diary;
    public GameObject atualizacaoDesafioRefeitorio;
    public DesafiosFinaisManager desafioFinal;
    public GameObject sombras;
    public GameObject grades;
    public GameObject gas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            diary.FillPage(atualizacaoDesafioRefeitorio);
            desafioFinal.progressao++;
            sombras.SetActive(false);
            grades.SetActive(false);
            gas.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
