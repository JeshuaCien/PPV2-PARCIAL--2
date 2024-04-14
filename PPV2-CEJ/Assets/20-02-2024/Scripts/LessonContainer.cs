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
    public string lessonName;

    //se ejecuta cuando se inicia en el primer frame para poder saber si el contenedor de Lessons (lessonContainer) está vació
    public void Start()
    {
        //Se verifica si lessonContainer no es nulo y luego llama al método OnUpdateUI()
        //el cual actualiza la interfaz de usuario con información sobre la lección actual.
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }
        //Si es nulo se manda un mensaje para asignar un objeto en la variable lessonContainer 
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }

    //actualiza la interfaz de usuario con información sobre la lección
    //actual para saber que lección se encuentra respondiendo el jugador
    public void OnUpdateUI()
    {
        //Verifica si StageTitle o LessonStage y TMP_Text que muestran el título y el número de la lección son nulos.
        if (StageTitle != null || LessonStage != null)
        {
            //Se actualiza el texto de StageTitle y LessonStage para poder saber que lesson se esta respondiendo.
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessons;
        }
        //Si los objetos son nulos y están vacios, se manda un mensaje para poder saber que se deben de revisar las variables.
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    // Este metodo activa/desactiva la ventana del LessonContainer
    public void EnableWindow()
    {
        //Se llama desde aquí el metodo OnUpdateUI();
        //para poder ser actualizado cada vez que se active la ventana donde aparecen el nombre y numero de lección
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
            //Se instancia SetSelectedLesson de MainSccript que se asigna con Lesson Name para poder ser leido el JSON
            MainSccript.Instance.SetSelectedLesson(lessonName);
        }
    }
}
