using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesafioLabBManager : MonoBehaviour
{
    private bool lanternaON = false;
    private bool caixa1ON = false;
    private bool caixa2ON = false;
    private bool caixa3ON = false;

    public DeixaLanterna lanterna;
    public TriggerCaixasLabB[] triggers;
    public DesafiosFinaisManager desafioFinal;

    private bool fim = false;

    public DialogueBase dialogo;
    public Diario diary;
    public GameObject atualizacaoDesafioLabB;

    private void Update()
    {
        if (triggers[0].caixaON) caixa1ON = true;
        else if (!triggers[0].caixaON) caixa1ON = false;

        if (triggers[1].caixaON) caixa2ON = true;
        else if (!triggers[1].caixaON) caixa2ON = false;

        if (triggers[2].caixaON) caixa3ON = true;
        else if (!triggers[2].caixaON) caixa3ON = false;

        if (lanterna.lanternaDown) lanternaON = true;
        else if (!lanterna.lanternaDown) lanternaON = false;

        if(lanternaON && caixa1ON && caixa2ON && caixa3ON && !fim)
        {
            desafioFinal.progressao++;
            DialogueManager.instance.EnqueueDialogue(dialogo);
            diary.FillPage(atualizacaoDesafioLabB);
            fim = true;
        }
    }
}
