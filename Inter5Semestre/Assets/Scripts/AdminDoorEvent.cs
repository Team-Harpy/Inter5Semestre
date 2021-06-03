using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AdminDoorEvent : MonoBehaviour
{
    [SerializeField]
    LockCamera lockCamera;
    [SerializeField]
    CinemachineVirtualCamera vcamLookAdmin;

    private VolumeManager volume;
    public float velocidadeTransicao;
    private BoxCollider bc;

    private void Start()
    {
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
        bc = GetComponent<BoxCollider>();
    }


    public void AdminDoorAnimationEventStart()
    {
        lockCamera.LockPlayerMovement();
        vcamLookAdmin.Priority = 2;
        volume.Transicao(velocidadeTransicao);
    }

    public void AdminDoorAnimationEventEnd()
    {
        lockCamera.UnlockPlayerMovement();
        vcamLookAdmin.Priority = 0;
        bc.enabled = false;
    }
}
