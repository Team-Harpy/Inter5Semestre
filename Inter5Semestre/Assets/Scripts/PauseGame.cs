using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool pausado = false;

    public GameObject pauseUI;

    private InputManager input;
    
    [SerializeField]
    private LockCamera lockCamera_;


    private void Start()
    {
        input = InputManager.Instance;
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (input.PlayerPause())
        {
            if (pausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        lockCamera_.UnlockPlayerCamera();
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    void Pause()
    {
        lockCamera_.LockPlayerCamera();
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }
}
