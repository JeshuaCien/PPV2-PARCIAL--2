using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarLesson : MonoBehaviour
{
    public bool pasarNivel;
    public int IndiceNivel;

    //Funcion que realiza un cambio de escena al apretar la barra espaciadora.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           //Cambiara a la escena la cual se indica con la variable IndiceNivel
            CambiarNivel(IndiceNivel);
        }
        //Se cambiara de escena si la variable bool se vulve true.
        if (pasarNivel)
        {
            CambiarNivel(IndiceNivel);
        }
    }

    // Funci�n que cambia de escena dependiendo del n�mero de indice que contenga, se asigna en int indice.
    public void CambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
