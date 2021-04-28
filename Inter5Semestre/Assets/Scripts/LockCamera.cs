using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class LockCamera : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;
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
}
