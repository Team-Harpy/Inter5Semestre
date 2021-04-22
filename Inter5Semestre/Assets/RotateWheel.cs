using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateWheel : Interactable
{
    private bool coroutineAllowed;
    [SerializeField]
    private int numberShown;

    public string wheelnumber;

    

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    public override void Interact()
    {
        
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheelCoroutine");
        }
    }

    private IEnumerator RotateWheelCoroutine()
    {
        coroutineAllowed = false;
        for(int i = 0; i <= 8; i++)
        {
            transform.Rotate(0f, -45f, 0f);
            yield return new WaitForSeconds(0.01f);

        }
        coroutineAllowed = true;
        numberShown += 1;
        if(numberShown > 7)
        {
            numberShown = 0;
        }

        GetComponentInParent<NumberLockController>().CheckCombination(wheelnumber, numberShown);
    }
}
