using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestiarioPuzzle : Interactable
{
    [SerializeField]
    bool puzzleCanStart;
    public bool puzzleSetup;
    [SerializeField]
    private PuzzleDoor[] vestiarioDoor;

    [SerializeField]
    private DesafiosFinaisManager desafiosManager;

    [SerializeField]
    private GameObject efeitoInteragivel;
    [SerializeField]
    private Diario diary;
    [SerializeField]
    private DialogueBase dialogo;
    [SerializeField]
    private GameObject atualizacao;
   


    private void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
       
    }

    public override void Interact()
    {
        if (puzzleCanStart)
        {
            Debug.Log("Chamou");
            for (int i = 0; i < vestiarioDoor.Length; i++)
            {
                puzzleCanStart = false;
                vestiarioDoor[i].puzzleStarted = true;
                vestiarioDoor[i].animator.SetBool("GoCrazy", false);
                vestiarioDoor[i].animator.speed = 1f;

            }
            
            RandomizeNewLocker();
            DialogueManager.instance.EnqueueDialogue(dialogo);
            diary.FillPage(atualizacao);
            puzzleCanStart = false;
        }
       




    }
    private void Update()
    {
        if (puzzleSetup)
        {
            for (int i = 0; i < vestiarioDoor.Length; i++)
            {
                Animator animator = vestiarioDoor[i].GetComponent<Animator>();
                animator.SetBool("GoCrazy", true);
                animator.speed = Random.Range(1f, 2.5f);
            }
            puzzleSetup = false;
            puzzleCanStart = true;
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

        efeitoInteragivel.SetActive(false);
        desafiosManager.progressao += 1;
        return true;
    }
     

  




}
