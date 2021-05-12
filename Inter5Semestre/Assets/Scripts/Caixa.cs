using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    [HideInInspector]
    public Vector3 end;
    [HideInInspector]
    public bool empurra = false;
    [HideInInspector]
    public bool bloqueia = false;
    [HideInInspector]
    public bool puxa = false;
    public float velocidade;

    private void Update()
    {
        if (empurra && !bloqueia)
            transform.position = Vector3.MoveTowards(transform.position, end, velocidade * Time.deltaTime);

        if (puxa)
            transform.position = Vector3.MoveTowards(transform.position, end, velocidade * Time.deltaTime);

        if (transform.position == end)
            empurra = false;
    }
}
