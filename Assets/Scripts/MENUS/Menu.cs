using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CarregarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void CarregarOPCOES()
    {
        SceneManager.LoadScene("OPCOES");
    }
    public void CarregarFase1()
    {
        SceneManager.LoadScene("FASE1");
    }
    public void CarregarPLAYGROUND()
    {
        SceneManager.LoadScene("PLAYGROUND");
    }
    public void CarregarTESTE()
    {
        SceneManager.LoadScene("TESTE");
    }
    public void VoltaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SairAPK()
    {
        Application.Quit();
    }
}
