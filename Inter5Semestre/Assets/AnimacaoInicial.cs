using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoInicial : MonoBehaviour
{
    [SerializeField]
    private DialogueBase dialogo;
    void Start()
    {
        StartCoroutine("AnimacaoInicialEvento");
    }

    IEnumerator AnimacaoInicialEvento()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        DialogueManager.instance.EnqueueDialogue(dialogo);


    }

  
}
