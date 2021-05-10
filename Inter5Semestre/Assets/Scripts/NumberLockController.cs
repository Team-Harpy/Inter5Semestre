using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NumberLockController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    private LockCamera lockCamera;

   
    private AnimationInteract animationInteractScript;

    [Header("Door")]
    [SerializeField]
    private GameObject cadeado;
    [SerializeField]
    private GameObject doorToOpen;
    [SerializeField]
    private Animator doorAnimator;
    [SerializeField]
    private string boolName;

    private InputManager inputManager;
    private int[] currentCode, correctCombination;

    [SerializeField]
    [Range(0,7)]
    private int firstNumber, secondNumber, thirdNumber;

    private void Start()
    {
        lockCamera = FindObjectOfType<LockCamera>().GetComponent<LockCamera>();
        currentCode = new int[] { 0, 0, 0 };
        correctCombination = new int[] { firstNumber, secondNumber, thirdNumber };
        inputManager = InputManager.Instance;
        doorAnimator = doorToOpen.GetComponent<Animator>();
    }

    private void Update()
    {
        if (inputManager.ExitLock())
        {
            ExitLock();
        }
    }
    public void CheckCombination(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "wheel1":
                currentCode[0] = number;
                break;

            case "wheel2":
                currentCode[1] = number;
                break;

            case "wheel3":
                currentCode[2] = number;
                break;
        }

        if(currentCode[0] == correctCombination[0] && currentCode[1] == correctCombination[1] && currentCode[2] == correctCombination[2])
        {
            UnlockDoor();
        }
    }

    void ExitLock()
    {
        this.gameObject.SetActive(false);
        lockCamera.UnlockPlayerCamera();
        lockCamera.UnlockPlayerMovement();
    }

   


    void UnlockDoor()
    {
        ExitLock();
        doorToOpen.GetComponent<AudioSource>().Play();
        doorAnimator.SetBool("Open", true);
        doorToOpen.AddComponent<AnimationInteract>();
        animationInteractScript = doorToOpen.GetComponent<AnimationInteract>();
        animationInteractScript.animator = doorToOpen.GetComponent<Animator>();
        animationInteractScript.boolAnimationName = boolName;
        Destroy(cadeado);
    }
}
