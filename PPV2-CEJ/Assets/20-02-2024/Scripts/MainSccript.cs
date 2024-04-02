using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSccript : MonoBehaviour
{
    //Comentar

    public static MainSccript Instance;
    public string SelectedLesson = "One";

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


    public void SetSelectedLesson(string lesson)
    {
        SelectedLesson = lesson;
        //Recurso usado para guardar por medio de un llave identificadora
        //un recurso ya sea booleano o string.
        PlayerPrefs.SetString("SelectedLesson1", SelectedLesson);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Lesson");
    }
}
