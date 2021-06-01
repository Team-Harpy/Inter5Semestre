using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentoComPaginas : MonoBehaviour
{
    public GameObject[] paginas;
    private int paginaAtual = 0;

    public void AvancaPagina()
    {
        paginas[paginaAtual].SetActive(false);

        paginaAtual++;
        if (paginaAtual >= paginas.Length) paginaAtual = paginas.Length - 1;

        paginas[paginaAtual].SetActive(true);
    }

    public void VoltaPagina()
    {
        paginas[paginaAtual].SetActive(false);

        paginaAtual--;
        if (paginaAtual < 0) paginaAtual = 0;

        paginas[paginaAtual].SetActive(true);
    }
}
