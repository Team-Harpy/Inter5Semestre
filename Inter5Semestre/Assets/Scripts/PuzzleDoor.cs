using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : Interactable
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    VestiarioPuzzle vestiarioPuzzle;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource acertoAudio;
    [SerializeField]
    private RespawnManager respawnManager;

    public Animator maozinha;

    public bool puzzleStarted;

    public bool correctLocker;
    public bool opened;

    public override void Interact()
    {
        if (puzzleStarted)
        {
            if (correctLocker)
            {
                // Debug.Log("Acertou");
                opened = true;
                animator.SetBool("Open", true);
                acertoAudio.Play();

                if (!vestiarioPuzzle.AllLockersOpened()) vestiarioPuzzle.RandomizeNewLocker();
                correctLocker = false;
            }

            else
            {
                respawnManager.StartCoroutine("Transicao", RespawnManager.Estados.VESTIARIO);
                maozinha.SetTrigger("pula");
                Debug.Log("errou");
            }

        }

        else if (!animator.GetBool("GoCrazy")) animator.SetBool("Open", !animator.GetBool("Open"));


    }

    private void Update()
    {
        if (correctLocker) audioSource.volume = 1;
        else audioSource.volume = 0f;
    }


    public void PlaySound()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
