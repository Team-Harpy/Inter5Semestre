using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberLockInteract : Interactable
{
    public GameObject numberlockCanvas;
    [SerializeField]
    private LockCamera lockCamera;
    
    public override void Interact()
    {
        numberlockCanvas.SetActive(true);
        lockCamera.LockPlayerCamera();
    }
}
