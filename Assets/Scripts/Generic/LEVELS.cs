using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LEVELS : MonoBehaviour
{
    private float Cronometro;
    public int Tempo;
    public string Cena;

    void Update()
    {
    }
        void OnTriggerEnter()
        {


            SceneManager.LoadScene(Cena);
            /*Cronometro += Time.deltaTime;
            if (Cronometro >= Tempo)
            {
                Application.LoadLevel(Cena);
            }*/


        }
        

}
