using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFlick : MonoBehaviour
{
    private Animator anim;
    public float chance;
    public float total;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(chance >= Random.Range(0, total))
        {
            anim.SetTrigger("Flick");
        }
    }
}
