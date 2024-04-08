using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSccript : MonoBehaviour
{
    //Variable usada en el Singleton para indicar que script se usa.
    public static MainSccript Instance;

    
    public string SelectedLesson = "Lesson";


    //Singleton-está función asegura que solo exista una instancia de la clase
    //durante el ciclo de vida de la aplicación. Si se intenta crear
    //una segunda instancia, simplemente se devuelve la instancia existente en lugar
    //de crear una nueva. Esto es útil en situaciones donde solo se necesita una única
    //instancia de una clase para ser compartida entre diferentes partes del código.
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

    /*/Este método establece la lección seleccionada en el juego. /*/
    public void SetSelectedLesson(string lesson)
    {
        /*/Tomamos el parámetro lesson, que es una cadena que representa la lección seleccionada, 
         * y lo asigna a la variable SelectedLesson./*/
        SelectedLesson = lesson;

        //Luego, utiliza PlayerPrefs.SetString() que es recurso usado para guardar por medio de un llave identificadora
        //un recurso ya sea booleano o string.
        PlayerPrefs.SetString("SelectedLesson", SelectedLesson);
    }


    /*/BeginGame(): Este método se llama para iniciar el juego. 
     * Utiliza SceneManager.LoadScene() para cargar la escena llamada "Lesson". /*/
    public void BeginGame()
    {
        /*/Esto indica que después de seleccionar una lección y llamar a BeginGame(), 
         * el juego cargará la escena "Lesson" para empezar a jugar./*/
        SceneManager.LoadScene("Lesson");
    }
}
