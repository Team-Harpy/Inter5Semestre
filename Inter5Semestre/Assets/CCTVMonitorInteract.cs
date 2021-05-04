using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CCTVMonitorInteract : Interactable
{
    [SerializeField]
    private GameObject sombraJumpscare;

    [SerializeField]
    private GameObject telefone;

    [SerializeField]
    private CinemachineVirtualCamera vcamCCTV;

    bool coroutineStart = true;


    public override void Interact()
    {
        if(coroutineStart)StartCoroutine("CCTVEvent");
    }


    IEnumerator CCTVEvent()
    {
        coroutineStart = false;
        vcamCCTV.Priority = 2;
        yield return new WaitForSeconds(1f);
        sombraJumpscare.SetActive(true);
        yield return new WaitForSeconds(4.2f);
        sombraJumpscare.SetActive(false);
        vcamCCTV.Priority = 0;
        telefone.GetComponent<AudioSource>().Play();
    }
}
