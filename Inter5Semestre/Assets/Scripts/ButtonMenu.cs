using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public int cenaACarregar;

    public GameObject loadingScreen;
    public Slider slider;
    public Text carregandoText;
    public void CarregaGame()
    {
        StartCoroutine("LoadGameScene");
    }

    public void CarregarCena()
    {
        SceneManager.LoadScene(cenaACarregar);
    }

    public void Sair()
    {
        Debug.Log("saiu");
        Application.Quit();
    }


    IEnumerator LoadGameScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        loadingScreen.SetActive(true);


        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
            
        }

        /*carregandoText.text = "Carregando";
            yield return new WaitForSeconds(.5f);
            carregandoText.text = "Carregando.";
            yield return new WaitForSeconds(.5f);
            carregandoText.text = "Carregando..";
            yield return new WaitForSeconds(.5f);
            carregandoText.text = "Carregando...";
            yield return new WaitForSeconds(.5f);
           */
    }
}
