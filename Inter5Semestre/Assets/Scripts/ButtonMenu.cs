using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public int cenaACarregar;

    public void CarregaCena()
    {
        SceneManager.LoadScene(cenaACarregar);
    }

    public void Sair()
    {
        Debug.Log("saiu");
        Application.Quit();
    }
}
