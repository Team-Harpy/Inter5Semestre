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
    public BoxCollider portaBC;
    public GameObject tranca;

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

        if(lanternaON && caixa1ON && caixa2ON && caixa3ON)
        {
            portaBC.enabled = true;
            tranca.SetActive(false);
        }
    }
}
