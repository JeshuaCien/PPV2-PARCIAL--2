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

    public void Start()
    {
        //Esta línea comprueba si la variable lessonContainer no es nula. Si lessonContainer es diferente de null,
        //significa que ha sido asignada en el Inspector de Unity.
        if (lessonContainer != null)
        {
            //Este método se encarga de actualizar la interfaz de usuario relacionada con la lección.
            OnUpdateUI();
        }
        else
        {
            //se emite un mensaje de advertencia a través de Debug.LogWarning(), indicando que hay un GameObject nulo
            Debug.LogWarning("GameObject Nulo, revisa las variables del tipo GameObject LessonContainer");
        }
    }

    //Metodo que actualiza la UI, actualiza en el menu el texto que indica el lesson.
    public void OnUpdateUI()
    {
        //Esta línea comprueba si los objetos StageTitle o LessonStage no son nulos. Esto se hace utilizando la operación
        if (StageTitle != null || LessonStage != null)
        {
            //Se actualiza el texto con el arreglo para indicar la lección.
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + CurrentLession + " de " + TotalLessons;
        }
        else
        {
            //Si no se cumple el codigo- se mandará un mensaje que avisa que no se han asignado
            //los objetos en sus slots correspondientes.
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
        }
    }
}