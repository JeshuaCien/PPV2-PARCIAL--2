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

   //Singleton que garantizar que una clase sólo tenga una instancia y proporcionar un punto de acceso a ella.
   //así se podrá acceder a este script.
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
        //Establecemos la cantidad de preguntas en la lección para poder ser selecinadas y actualizadas.
        questionAmount = Lesson.leccionList.Count;
        // Cargar la primera pregunta
        LoadQuestion();

        //Se llama la función para poder checar si se tiene una opcion selecionada.
        CheckPlayerState();
    }

    //Función que carga la siguiente pregunta.
    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual este dentro de los limites de la cantidad de preguntas asignadas.
        if (currentQuestion < questionAmount)
        {
            //Establecemos la lección actual.
            currentLesson = Lesson.leccionList[currentQuestion];

            //Establecemos la pregunta.
            question = currentLesson.lessons;

            //Establecemos la pregunta correcta asignandola con la variable correctAnswer.
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];

            //Establecemos la pregunta en la UI para que aparezca la pregunta.
            textQuestion.text = question;

            //Establecemos las opciones con for que recorre todas las opciones.
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                //Este bloque de código sirve para iterar a través de una lista de opciones
                //y actualizar las propiedades de los componentes Option adjuntos a los objetos Question.

                // Esto implica que cada Question tiene un componente Option al que se puede acceder.
                Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];

                // Esto sugiere que OptionID probablemente se use para identificar cada opción de manera única.
                Question[i].GetComponent<Option>().OptionID = i;

                //este método actualiza el texto mostrado en el componente Option basado en la opción seleccionada.
                Question[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
            //Si no se cumple las reglas anteriores se manda un mensaje el cual dice:
            // "llegamos al final de las preguntas."
            Debug.Log("Fin de las preguntas");
        }
    }

    // Funcioón que nos manda a la siguiente pregunta.
    public void NextQuestion()
    {
        //Checa el estado de la respuesta que seleciona el jugador.
        if (CheckPlayerState())
        {
            //Aseguramos que la pregunta actual este dentro de los limites de la cantidad de preguntas asignadas.
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la pregunta es correcta o no.
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                // se activa la ventana que comprueba la respuesta en la UI.
                AnswerContainer.SetActive(true);

                // Se revisa si la respuesta es correcta o no es correcta.
                if (isCorrect)
                {
                    //Si sí es correcta, se actualizara el componente Image
                    //y se pondra de color verde para referencias que esta correcta la respuesta.
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //Se actualiza el texto, usando un arreglo para poner el mensaje que deseamos mostrar y las variables
                    //string que contienen una cadena de letras.
                    textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                }
                else
                {
                    //Si no es correcta, se actualizara el componente Image
                    //y se pondra de color rojo para referencias que esta incorrecta la respuesta.
                    AnswerContainer.GetComponent<Image>().color = Red;
                    //Se actualiza el texto, usando un arreglo para poner el mensaje que deseamos mostrar y las variables
                    //string que contienen una cadena de letras.
                    textGood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
                }

                // Incrementamos el indice de la pregunta actual para que no se repita la pregunta.
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

    //Función que asigna la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
     //Esta línea actualiza la respuesta del jugador con el valor proporcionado como argumento a la función.
        answerFromPlayer = _answer;
    }

    //Función que revisa si el jugador interactua con un boton para cambiar el color de los botones y activarlos.
    public bool CheckPlayerState()
    {
        // Checamos que al interactuar con los botones, estos cambien de color al ser seleccionados.
        if (answerFromPlayer != 9)
        {
            // Si no se interactua se pondra de color gris indicando que se puede interactuar con el.
            //Se actualiza el componente button para hacer que se pueda pulsar.
            CheckButton.GetComponent<Button>().interactable = true;
            //Se actualiza en el componente image para cambiar su color.
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;
        }
        else
        {
            // Si no sí interactua se pondra de color blanco idicando que no se puede interactuar con el botón.
            //Se actualiza el componente button para hacer que no se pueda pulsar.
            CheckButton.GetComponent<Button>().interactable = false;
            //Se actualiza en el componente image para cambiar su color.
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
