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
    

    public bool puzzleStarted;

    public bool correctLocker;
    public bool opened;
    public override void Interact()
    {
        if (correctLocker)
        {
            correctLocker = false;
            opened = true;
            animator.SetBool("Open", true);
            if (!vestiarioPuzzle.AllLockersOpened()) vestiarioPuzzle.RandomizeNewLocker();
        }

        if (!animator.GetBool("GoCrazy")) animator.SetBool("Open", !animator.GetBool("Open"));


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
