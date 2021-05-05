using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanosManager : MonoBehaviour
{
    public Animator bola1;
    public Animator bola2;
    public Animator bola3;

    public void Pulsa()
    {
        bola1.SetBool("pulsa", true);
        bola2.SetBool("pulsa", true);
        bola3.SetBool("pulsa", true);
    }

    public void PulsaOff()
    {
        bola1.SetBool("pulsa", false);
        bola2.SetBool("pulsa", false);
        bola3.SetBool("pulsa", false);
    }
}
