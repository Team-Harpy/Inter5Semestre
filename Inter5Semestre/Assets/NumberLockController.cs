using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLockController : MonoBehaviour
{
    private int[] currentCode, correctCombination;

    [SerializeField]
    private int firstNumber, secondNumber, thirdNumber;

    private void Start()
    {
        currentCode = new int[] { 0, 0, 0 };
        correctCombination = new int[] { firstNumber, secondNumber, thirdNumber };
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
            Debug.Log("Poggers");
        }
    }
}
