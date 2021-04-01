using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stress : MonoBehaviour
{
    [SerializeField]
    private Transform sombra;
    private float distance;
    [SerializeField]
    private Text textoDistance;


    private void Update()
    {
        distance = Vector3.Distance(transform.position, sombra.position);
        textoDistance.text = distance.ToString("F0");
    }

}
