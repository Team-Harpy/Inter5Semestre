using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class LockCamera : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    [SerializeField]
    private PlayerController pc;
    public void LockPlayerCamera()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0f;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0f;
    }

    public void UnlockPlayerCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = 0.1f;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = 0.1f;
    }

    public void LockPlayerMovement()
    {
        pc.interacting = true;
    }

    public void UnlockPlayerMovement()
    {
        pc.interacting = false;
    }
}
