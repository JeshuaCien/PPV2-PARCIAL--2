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
    public TMP_Text textGood;
    public List<Option> Question;
    public GameObject CheckButton;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 9;

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
        // Cargar la primera pregunta
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

    // Funcioón que nos manda a la siguiente pregunta.
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la pregunta es correcta o no.
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                // se activa la ventana que comprueba la respuesta en la UI.
                AnswerContainer.SetActive(true);

                // Se revisa si la respuesta es correcta o no es correcta.
                if (isCorrect)
                {
                    AnswerContainer.GetComponent<Image>().color = Green;
                    textGood.text = "Respuesta correcta." + question + ":" + correctAnswer;
                }
                else
                {
                    AnswerContainer.GetComponent<Image>().color = Red;
                    textGood.text = "Respuesta incorrecta." + question + ":" + correctAnswer;
                }

                // Incrementamos el indice de la pregunta actual
                currentQuestion++;

                //Se llama la funcion ShowResultAndLoadQuestion que comienza una corrutina la cual
                //suspendera por 2.5 segundos el proceso de comprobar y cambiar de pregunta.
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                // reiniciar la respuesta del usuario
                answerFromPlayer = 9;
                
            }
            else
            {
                //Cambio la escena
            }
        }
    }

    //Función que inicia una corrutina la cual suspende el proceso del codigo
    //dependiendo lo que se especifique dentro de está misma función.
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        //Ajusta el tiempo que deseas mostrar el resultado
        yield return new WaitForSeconds(2.5f);

        //Ocultar el contenedor de respuestas.
        AnswerContainer.SetActive(false);

        //Cargar la nueva pregunta
        LoadQuestion();

        //Activar el botón después de mostrar el resultado.
        //Puedes hacer esto aquí o en LoadQuestion(), dependiendo de tu estructura por ejemplo,
        //si el boton está en el mismo GmaeObject que el Script:
        //GetComponent<Button>().interactable = true;
        CheckPlayerState();
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    public bool CheckPlayerState()
    {
        // Checamos que al interactuar con los botones, estos cambien de color al ser seleccionados.
        if (answerFromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
