using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    private Renderer render;
    public Material mundoReal;
    public Material alucinacao;
    private VolumeManager volume;

    private void Start()
    {
        render = GetComponent<Renderer>();
        volume = GameObject.FindGameObjectWithTag("VolumeManager").GetComponent<VolumeManager>();
    }

    private void Update()
    {
        if (volume.emAlucinacao)
        {
            render.sharedMaterial = alucinacao;
        }
        else if (!volume.emAlucinacao)
        {
            render.sharedMaterial = mundoReal;
        }
    }
}
