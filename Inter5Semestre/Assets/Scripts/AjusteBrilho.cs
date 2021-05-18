using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AjusteBrilho : MonoBehaviour
{
    public Volume brilho;
    public Slider barra;

    private void Update()
    {
        brilho.weight = barra.value;
    }
}
