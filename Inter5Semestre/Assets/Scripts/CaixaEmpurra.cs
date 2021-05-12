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
    private bool puxa = false;
    public Transform target;

    private void Update()
    {
        Ray raio = new Ray(target.position, -transform.forward);
        Debug.DrawRay(raio.origin, raio.direction * 0.2f, Color.cyan);
        RaycastHit hit;
        if(Physics.Raycast(raio, out hit, 0.2f))
        {
            if (hit.collider.CompareTag("Caixa") || hit.collider.CompareTag("Parede"))
            {
                bloqueia = true;
            }
        }
        else
            bloqueia = false;

        if (empurra && !bloqueia)
            caixa.position = Vector3.MoveTowards(caixa.position, end, velocidade * Time.deltaTime);

        if (puxa)
            caixa.position = Vector3.MoveTowards(caixa.position, end, velocidade * Time.deltaTime);

        if (caixa.position == end)
            empurra = false;

        //Debug.Log(bloqueia);
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

        puxa = true;
    }
}
