using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NumberLockInteract : Interactable
{
    public GameObject numberlockCanvas;
    public CinemachineVirtualCamera camera;
    public override void Interact()
    {
        numberlockCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        camera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0f;
        camera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0f;
    }
}
