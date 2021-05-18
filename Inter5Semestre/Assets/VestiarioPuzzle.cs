using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestiarioPuzzle : Interactable
{
    [SerializeField]
    bool puzzleCanStart;
    [SerializeField]
    private GameObject[] vestiarioDoor;

    public override void Interact()
    {
        foreach (GameObject item in vestiarioDoor)
        {
            Animator animator = item.GetComponent<Animator>();
            animator.SetBool("GoCrazy", false);
            animator.speed = 1f;
        }

      
    }
    private void Update()
    {
        if (puzzleCanStart)
        {
            foreach (GameObject item in vestiarioDoor)
            {
                Animator animator = item.GetComponent<Animator>();
                animator.SetBool("GoCrazy", true);
                animator.speed = Random.Range(1f, 2.5f);
            }
            puzzleCanStart = false;
        }


    }
     

  




}
