using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaEmpurra : MonoBehaviour
{
    public Transform caixa;
    public bool north = false;
    public bool east = false;
    public bool south = false;
    public bool west = false;
    public float velocidade;
    private Vector3 end;
    private bool empurra = false;
    private bool bloqueia = false;

    private void Update()
    {
        if(empurra)
            caixa.position = Vector3.MoveTowards(caixa.position, end, velocidade * Time.deltaTime);

        if (caixa.position == end)
            empurra = false;
    }

    public void Empurra()
    {
        if (north)
            end = new Vector3(caixa.position.x, caixa.position.y, caixa.position.z - 1);
        else if (east)
            end = new Vector3(caixa.position.x - 1, caixa.position.y, caixa.position.z);
        else if (south)
            end = new Vector3(caixa.position.x, caixa.position.y, caixa.position.z + 1);
        else if (west)
            end = new Vector3(caixa.position.x + 1, caixa.position.y, caixa.position.z);

        empurra = true;
    }

    public void Puxa()
    {
        if (north)
            end = new Vector3(caixa.position.x, caixa.position.y, caixa.position.z + 1);
        else if (east)
            end = new Vector3(caixa.position.x + 1, caixa.position.y, caixa.position.z);
        else if (south)
            end = new Vector3(caixa.position.x, caixa.position.y, caixa.position.z - 1);
        else if (west)
            end = new Vector3(caixa.position.x - 1, caixa.position.y, caixa.position.z);

        empurra = true;
    }
}
