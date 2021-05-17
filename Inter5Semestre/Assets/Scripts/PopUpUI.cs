using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public Animator diaryAnim;
    public Animator mapAnim;
    InputManager inputManager;

    [HideInInspector]
    public bool diaryOpened;
    private bool mapOpened;
    [HideInInspector]
    public bool hasDiary;
    [SerializeField]
    private AudioClip abreDiario;
    [SerializeField]
    private AudioClip fechaDiario;

    private AudioSource audiosource;


   
    public bool hasMap;

    [SerializeField]
    private LockCamera lockCamera;

    private void Start()
    {
        inputManager = InputManager.Instance;
        diaryOpened = false;
        mapOpened = false;
        hasDiary = false;
        audiosource = GetComponent<AudioSource>();

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
                OpenDiarySound();
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
                ClosedDiarySound();
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



    public void OpenDiaryStart()
    {
        diaryAnim.SetTrigger("popUp");
        diaryOpened = true;
        lockCamera.LockPlayerCamera();
        OpenDiarySound();
    }
    public void OpenMapStart()
    {
        mapAnim.SetTrigger("popUp");
        mapOpened = true;
    }



    private void OpenDiarySound()
    {
        audiosource.clip = abreDiario;
        audiosource.Play();
    }

    private void ClosedDiarySound()
    {
        audiosource.clip = fechaDiario;
        audiosource.Play();
    }
}
