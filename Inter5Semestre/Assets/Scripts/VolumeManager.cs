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
    private bool transicionaOut;
    private DialogueBase dialogo;
    public GameObject objetosFlutuantes;
    public GameObject objetosEstaticos;
    [SerializeField]
    private AudioSource backgroundSound;
    [SerializeField]
    private AudioSource musicSound;
    private PlayerController player;
    [HideInInspector]
    public bool emAlucinacao = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

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
            if(backgroundSound.volume <= 1f)
            {
                backgroundSound.volume += transitionSpeed * Time.deltaTime;
            }
            

            if (alucinacao.weight >= 1)
            {
                transiciona = false;
            }
        }

        if (transicionaOut)
        {
            alucinacao.priority = 0;
            real.priority = 1;
            real.weight += transitionSpeed * Time.deltaTime;

            if(real.weight >= 1)
            {
                transicionaOut = false;
            }
        }
    }

    public void Transicao(float speed)
    {
        objetosEstaticos.SetActive(false);
        objetosFlutuantes.SetActive(true);
        player.flashlightCanFail = true;
        emAlucinacao = true;
        alucinacao.weight = 0;
        transitionSpeed = speed;
        transiciona = true;
        musicSound.volume = 0.01f;
        backgroundSound.Play();
        
    }
    public void Transicao(float speed, DialogueBase dialogo2)
    {
        objetosEstaticos.SetActive(false);
        objetosFlutuantes.SetActive(true);
        player.flashlightCanFail = true;
        emAlucinacao = true;
        dialogo = dialogo2;
        StartCoroutine("WaitForDialogue");
        alucinacao.weight = 0;
        transitionSpeed = speed;
        transiciona = true;
        musicSound.volume = 0.01f;
        backgroundSound.Play();
    }

    public void TransicaoOut(float speed)
    {
        objetosEstaticos.SetActive(true);
        objetosFlutuantes.SetActive(false);
        player.flashlightCanFail = false;
        emAlucinacao = false;
        real.weight = 0;
        transitionSpeed = speed;
        transicionaOut = true;
        musicSound.volume = 0.05f;
        backgroundSound.Stop();
        backgroundSound.volume = 0f;
    }

    IEnumerator WaitForDialogue()
    {
        yield return new WaitForSeconds(2f);
        DialogueManager.instance.EnqueueDialogue(dialogo);
    }
}
