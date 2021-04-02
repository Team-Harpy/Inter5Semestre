using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public Animator diaryAnim;
    public Animator mapAnim;
    InputManager inputManager;

    private bool diaryOpened;
    private bool mapOpened;

    private void Start()
    {
        inputManager = InputManager.Instance;
        diaryOpened = false;
        mapOpened = false;
    }

    private void Update()
    {
        if(diaryOpened == false && mapOpened == false)
        {
            if (inputManager.DiaryUp())
            {
                diaryAnim.SetTrigger("popUp");
                diaryOpened = true;
            }

            if (inputManager.OpenMap())
            {
                mapAnim.SetTrigger("popUp");
                mapOpened = true;
            }
        }

        else if (diaryOpened == true && mapOpened == false)
        {
            if (inputManager.DiaryUp())
            {
                diaryAnim.SetTrigger("popUp");
                diaryOpened = false;
            }
        }

        else if (diaryOpened == false && mapOpened == true)
        {
            if (inputManager.OpenMap())
            {
                mapAnim.SetTrigger("popUp");
                mapOpened = false;
            }
        }
    }
}
