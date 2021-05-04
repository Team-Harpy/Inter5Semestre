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
    [HideInInspector]
    public bool hasDiary;

   
    public bool hasMap;

    [SerializeField]
    private LockCamera lockCamera;

    private void Start()
    {
        inputManager = InputManager.Instance;
        diaryOpened = false;
        mapOpened = false;
        hasDiary = false;
    }

    private void Update()
    {
    


        if(diaryOpened == false && mapOpened == false)
        {
            if (inputManager.DiaryUp() && hasDiary)
            {
                diaryAnim.SetTrigger("popUp");
                diaryOpened = true;
                lockCamera.LockPlayerCamera();
            }

            if (inputManager.OpenMap() && hasMap)
            {
                mapAnim.SetTrigger("popUp");
                mapOpened = true;
            }
        }

        else if (diaryOpened == true && mapOpened == false)
        {
            if (inputManager.DiaryUp() && hasDiary)
            {
                diaryAnim.SetTrigger("popUp");
                diaryOpened = false;
                lockCamera.UnlockPlayerCamera();
            }
        }

        else if (diaryOpened == false && mapOpened == true)
        {
            if (inputManager.OpenMap()&& hasMap)
            {
                mapAnim.SetTrigger("popUp");
                mapOpened = false;
            }
        }
    }
}
