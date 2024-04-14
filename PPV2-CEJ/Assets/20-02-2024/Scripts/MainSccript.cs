using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSccript : MonoBehaviour
{
    //Variable usada en el Singleton para indicar que script se usa.
    public static MainSccript Instance;

    
    public string SelectedLesson = "Lesson";


    //Singleton-est� funci�n asegura que solo exista una instancia de la clase
    //durante el ciclo de vida de la aplicaci�n. Si se intenta crear
    //una segunda instancia, simplemente se devuelve la instancia existente en lugar
    //de crear una nueva. Esto es �til en situaciones donde solo se necesita una �nica
    //instancia de una clase para ser compartida entre diferentes partes del c�digo.
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    /*/SetSelectedLesson establece la lecci�n seleccionada en el juego. /*/
    public void SetSelectedLesson(string lesson)
    {
        /*/Tomamos el par�metro lesson, que es una cadena que representa la lecci�n seleccionada, 
         * y lo asigna a la variable SelectedLesson./*/
        SelectedLesson = lesson;

        //Luego, utiliza PlayerPrefs.SetString() que es recurso usado para guardar por medio de un llave identificadora
        //un recurso ya sea booleano o string.
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }


    /*/BeginGame(): se llama para iniciar el juego. 
     * Utiliza SceneManager.LoadScene() para cargar la escena llamada "Lesson". /*/
    public void BeginGame()
    {
        /*/Esto indica que despu�s de seleccionar una lecci�n y llamar a BeginGame(), 
         * el juego cargar� la escena "Lesson" para empezar a jugar./*/
        SceneManager.LoadScene("1Lesson");
    }
}
