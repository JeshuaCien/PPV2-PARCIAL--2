using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int CurrentLession = 0;
    public int TotalLessons = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;
    

    [Header("Lesson Data")]
    public ScriptableObject LessonData;
    public string lessonA = "LessonName"; 

    public void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }


    public void OnUpdateUI()
    {
        if (StageTitle != null || LessonStage != null)
        {
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessons;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    // Este metodo activa/desactiva la ventana del LessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
            //Desactiva el objecto si está activo.
            lessonContainer.SetActive(false);
        }
        else
        {
            //Activa el objeto si está desactivado.
            lessonContainer.SetActive(true);
            MainSccript.Instance.SetSelectedLesson("LessonName");
        }
    }
}
