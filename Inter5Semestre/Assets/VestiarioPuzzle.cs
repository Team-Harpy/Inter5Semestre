using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestiarioPuzzle : Interactable
{
    [SerializeField]
    bool puzzleCanStart;
    [SerializeField]
    private PuzzleDoor[] vestiarioDoor;

    

  

  

    public override void Interact()
    {

        for (int i = 0; i < vestiarioDoor.Length; i++)
        {
            puzzleCanStart = false;
            vestiarioDoor[i].puzzleStarted = true;
            vestiarioDoor[i].animator.SetBool("GoCrazy", false);
            vestiarioDoor[i].animator.speed = 1f;
            
        }

        RandomizeNewLocker();



    }
    private void Update()
    {
        if (puzzleCanStart)
        {
            for (int i = 0; i < vestiarioDoor.Length; i++)
            {
                Animator animator = vestiarioDoor[i].GetComponent<Animator>();
                animator.SetBool("GoCrazy", true);
                animator.speed = Random.Range(1f, 2.5f);
            }
            puzzleCanStart = false;
        }


    }

    public void RandomizeNewLocker()
    {
        PuzzleDoor newCorrectLocker = vestiarioDoor[Random.Range(0, vestiarioDoor.Length)];
      


        while (newCorrectLocker.opened)
        {
            newCorrectLocker = vestiarioDoor[Random.Range(0, vestiarioDoor.Length)];
        }

        newCorrectLocker.correctLocker = true;
        
    }


    public bool AllLockersOpened()
    {
        for (int i = 0; i < vestiarioDoor.Length; i++)
        {
            if(vestiarioDoor[i].opened == false)
            {
                return false;
            }
        }

        
        return true;
    }
     

  




}
