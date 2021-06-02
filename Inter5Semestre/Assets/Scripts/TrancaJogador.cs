using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrancaJogador : MonoBehaviour
{
    public GameObject porta;
    private Animator anim;
    private PortaFinal interagivel;

    private void Start()
    {
        anim = porta.GetComponent<Animator>();
        interagivel = porta.GetComponent<PortaFinal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Open", false);
            interagivel.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
