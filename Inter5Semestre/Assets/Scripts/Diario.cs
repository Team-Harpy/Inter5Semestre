using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diario : MonoBehaviour
{
    InputManager inputManager;

    private bool firstPage = true;

    [SerializeField]
    private GameObject newPageSet;

    [SerializeField]
    private List<GameObject> pages = new List<GameObject>();

    [SerializeField]
    private int currentPage; // 1 = 1/2 ; 3 = 3/4 ...

    [SerializeField]
    private bool leftPageFilled;
    [SerializeField]
    private bool bothPagesFilled;

    [SerializeField]
    private GameObject lastUpdate, lastUpdate2;
   

    [SerializeField]
    private Transform leftPosition, rightPosition;



    private void Start()
    {        
        inputManager = InputManager.Instance;
        currentPage = 0;
    }

    private void Update()
    {
        
    }

    public void NextPage()
    {
        if(currentPage+1 >= pages.Count)
        {
            return;
        }

        else
        {
            pages[currentPage].SetActive(false);
            pages[currentPage + 1].SetActive(true);
            currentPage += 1;

        }

    }

    public void PreviousPage()
    {
        if(currentPage >= 0)
        {
            pages[currentPage].SetActive(false);
            pages[currentPage - 1].SetActive(true);
            currentPage -= 1;
        }
    }


    public void FillPage(GameObject atualizacao)
    {
        if (bothPagesFilled)
        {                     
                pages[currentPage].SetActive(false);
                currentPage += 1;
                bothPagesFilled = false;
                leftPageFilled = false;
                firstPage = false;                          
            

        }

        if (!leftPageFilled)
        {
            newPageSet = new GameObject("Page" + currentPage);
            newPageSet.transform.parent = this.gameObject.transform;
            pages.Add(newPageSet);
            atualizacao.transform.position = leftPosition.position;
            atualizacao.transform.parent = newPageSet.transform;
            leftPageFilled = true;
            
        }
        else
        {
            atualizacao.transform.parent = newPageSet.transform;
            atualizacao.transform.position = rightPosition.position;
            bothPagesFilled = true;
        }
        if(lastUpdate!= null) lastUpdate2 = lastUpdate;
       
        lastUpdate = atualizacao;
              
    }
}
