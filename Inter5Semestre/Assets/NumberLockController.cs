using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NumberLockController : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    private InputManager inputManager;
    private int[] currentCode, correctCombination;

    [SerializeField]
    [Range(0,7)]
    private int firstNumber, secondNumber, thirdNumber;

    private void Start()
    {
        currentCode = new int[] { 0, 0, 0 };
        correctCombination = new int[] { firstNumber, secondNumber, thirdNumber };
        inputManager = InputManager.Instance;
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
            ExitLock();
        }
    }



    void ExitLock()
    {
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0.1f;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0.1f;
    }
}
