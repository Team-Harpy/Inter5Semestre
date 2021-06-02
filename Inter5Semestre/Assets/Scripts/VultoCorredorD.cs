using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VultoCorredorD : MonoBehaviour
{
    private PlayerController player;
    public CinemachineVirtualCamera lookAtDoor;
    public GameObject vulto;
    public Animator porta;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("SequenciaVulto");
        }
    }

    IEnumerator SequenciaVulto()
    {
        player.interacting = true;
        lookAtDoor.Priority = 2;
        yield return new WaitForSeconds(2f);

        porta.SetBool("Open", true);
        vulto.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        porta.SetBool("Open", false);
        vulto.SetActive(false);
        player.interacting = false;
        lookAtDoor.Priority = 0;
        gameObject.SetActive(false);
    }
}
