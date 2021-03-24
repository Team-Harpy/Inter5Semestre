using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMonsterOffOn : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "monsterTest" && playerController.flashlightOn == true)
         {
             Debug.Log("acertou");
             other.GetComponent<SpriteRenderer>().enabled = true;
         }
     }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "monsterTest" )
        {           
            other.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("saiu");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "monsterTest")
        {
            if(playerController.flashlightOn == true)
            {
                other.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (playerController.flashlightOn == false)
            {
                other.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
