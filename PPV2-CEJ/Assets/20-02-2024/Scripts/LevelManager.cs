using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Level Data")]
    public Leccion Lesson;

    [Header("User interface")]
    public TMP_Text textQuestion;
    public List<Option> Question;


    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer;

    [Header("Current Lesson")]
    public Subject currentLesson;

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

    void Start()
    {
        //Establecemos la cantidad de preguntas en la lección.
        questionAmount = Lesson.leccionList.Count;
        LoadQuestion();
    }


    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            //Establecemos la lección actual.
            currentLesson = Lesson.leccionList[currentQuestion];

            //Establecemos la pregunta.
            question = currentLesson.lessons;

            //Establecemos la pregunta correcta.
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];

            //Establecemos la pregunta en UI
            textQuestion.text = question;

            //Establecemos las opciones
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Question[i].GetComponent<Option>().OptionID = i;
                Question[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
            //Si llegamos al final de las preguntas.
            Debug.Log("Fin de las preguntas");
        }
    }

    public void NextQuestion()
    {
        if (currentQuestion < questionAmount)
        {
            // Incrementamos el indice de la pregunta actual
            currentQuestion++;
            //Cargar la nueva pregunta
            LoadQuestion();
            ValidarOpcion();
        }
        else
        {
            //Cambio la escena
        }
    }
    //Intento de crear un funcion que valide la respuesta.
    public void ValidarOpcion()
    {
        if (correctAnswer != null)
        {
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];
            }
            return;
            Debug.Log("Respuesta incorrecta");
        }
        else
        {
            Debug.Log("Respuesta correcta");
        }
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }
}
