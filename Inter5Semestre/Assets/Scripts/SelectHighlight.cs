using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHighlight : MonoBehaviour
{
    public Color normal = Color.black;
    public Color selected = Color.yellow * 0.7f;
    private MeshRenderer render;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material.EnableKeyword("_EMISSION");
    }

    public void On()
    {
        render.material.SetColor("_EmissionColor", selected);
    }

    public void Off()
    {
        render.material.SetColor("_EmissionColor", normal);
        //Debug.Log("alou");
    }
}
