using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diario : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField]
    private int currentPage; // 1 = 1/2 ; 3 = 3/4 ...

    private void Start()
    {        
        inputManager = InputManager.Instance;
        currentPage = 1;
    }

    private void Update()
    {
        
    }

    public void NextPage()
    {
        currentPage += 2;
    }

    public void PreviousPage()
    {
        if(currentPage >= 3)
        {
            currentPage -= 2;
        }
    }
}
