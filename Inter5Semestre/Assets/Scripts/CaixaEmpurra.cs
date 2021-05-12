using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaEmpurra : MonoBehaviour
{
    public Caixa caixa;
    public bool north = false;
    public bool east = false;
    public bool south = false;
    public bool west = false;
    public float velocidade;

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
                caixa.bloqueia = true;
            }
        }
        else
            caixa.bloqueia = false;
    }

    public void Empurra()
    {
        if (north)
            caixa.end = new Vector3(caixa.transform.position.x, caixa.transform.position.y, caixa.transform.position.z - 1);
        else if (east)
            caixa.end = new Vector3(caixa.transform.position.x - 1, caixa.transform.position.y, caixa.transform.position.z);
        else if (south)
            caixa.end = new Vector3(caixa.transform.position.x, caixa.transform.position.y, caixa.transform.position.z + 1);
        else if (west)
            caixa.end = new Vector3(caixa.transform.position.x + 1, caixa.transform.position.y, caixa.transform.position.z);

        caixa.empurra = true;
    }

    public void Puxa()
    {
        if (north)
            caixa.end = new Vector3(caixa.transform.position.x, caixa.transform.position.y, caixa.transform.position.z + 1);
        else if (east)
            caixa.end = new Vector3(caixa.transform.position.x + 1, caixa.transform.position.y, caixa.transform.position.z);
        else if (south)
            caixa.end = new Vector3(caixa.transform.position.x, caixa.transform.position.y, caixa.transform.position.z - 1);
        else if (west)
            caixa.end = new Vector3(caixa.transform.position.x - 1, caixa.transform.position.y, caixa.transform.position.z);

        caixa.puxa = true;
    }
}
