using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeManager : MonoBehaviour
{
    public Volume real;
    public Volume alucinacao;
    private float transitionSpeed;
    private bool transiciona;
    private DialogueBase dialogo;

    private void Start()
    {
        real.priority = 1;
        alucinacao.priority = 0;

        transitionSpeed = 0;
        transiciona = false;
    }

    private void Update()
    {
        if (transiciona)
        {
            real.priority = 0;
            alucinacao.priority = 1;
            alucinacao.weight += transitionSpeed * Time.deltaTime;

            if (alucinacao.weight >= 1)
            {
                transiciona = false;
            }
        }
    }

    public void Transicao(float speed)
    {
        alucinacao.weight = 0;
        transitionSpeed = speed;
        transiciona = true;
    }
    public void Transicao(float speed, DialogueBase dialogo2)
    {
        dialogo = dialogo2;
        StartCoroutine("WaitForDialogue");
        alucinacao.weight = 0;
        transitionSpeed = speed;
        transiciona = true;
    }

    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(2f);
        DialogueManager.instance.EnqueueDialogue(dialogo);
    }
}
