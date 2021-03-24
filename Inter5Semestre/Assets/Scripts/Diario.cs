using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diario : MonoBehaviour
{
    Animator anim;
    InputManager inputManager;

    private void Start()
    {
        anim = GetComponent<Animator>();
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (inputManager.DiaryUp())
        {
            anim.SetTrigger("diario");
        }
    }
}
