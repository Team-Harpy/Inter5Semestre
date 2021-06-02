using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanosAnim : MonoBehaviour
{
    private VolumeManager volume;
    private Animator anim;

    private void Start()
    {
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (volume.emAlucinacao)
        {
            anim.SetBool("surto", true);
        }
        else if (!volume.emAlucinacao)
        {
            anim.SetBool("surto", false);
        }
    }
}
