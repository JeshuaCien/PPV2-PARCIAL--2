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

  /*/Singleton metodo que asegura que solo exista una instancia de la clase
    durante el ciclo de vida de la aplicación. Si se intenta crear
    una segunda instancia, simplemente se devuelve la instancia existente en lugar
    de crear una nueva. Esto es útil en situaciones donde solo se necesita una única
    instancia de una clase para ser compartida entre diferentes partes del código.
    /*/
    private void Awake()
    {
        //Esta línea comprueba si ya existe una instancia de SaveSystem.
        //Si ya existe, simplemente se sale del método, lo que significa que no se crea una nueva instancia.
        if (Instance != null)
        {
            return;
        }
        //Si no existe una instancia ´SaveSystem´, se asigna la instancia actual de la variable Instance,
        //la cual sirve para que la instancia sea unica, así se podra acceder a ella usando SaveSystem.Instance;.
        else
        {
            Instance = this;
        }
    }

    //Metodo que se inicializa desde el primer frame y se establece que se cargue la pregunta junto con sus respuestas.
    void Start()
    {
        //Establecemos la cantidad de preguntas en la lección.
        questionAmount = Lesson.leccionList.Count;
        // Cargar la primera pregunta con la función LoadQuestion la cual establece la lección actual,
        // actualiza la pregunta de la UI y establece las opciones.
        LoadQuestion();

        //Se llama la función para poder checar si se tiene una opcion selecionada.
        CheckPlayerState();
    }


    //Metodo cargar y mostrar las preguntas y opciones en la interfaz de usuario durante el juego.
    //Además de utilizar una clave for la cual recorre las lecciones hasta que ya no existan más preguntas que mostrar.
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

            //Establecemos las opciones y
            //se realiza una clave for para repetir la actualización de las preguntas y sus opciones en tiempo de ejecución.
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

    // Método que Carga la siguiente pregunta, usando if para poder cargar la pregunta si se cumplen las condiciones.
    //Se establece que sí se cumple la condición del CheckPlayerState() el cual checa si se seleciono el botón, al selecionarse,
    //se checa que la pregunta actual este dentro de los limites.
    /*/Se usa en una condicin que tiene un botón comrpobar para que al ser selecionado, se active este método/*/
    public void NextQuestion()
    {
        //Condicion que checa si se interactua con los botónes de la UI botón comprobar).
        if (CheckPlayerState())
        {
            //se checa que la pregunta actual este dentro de los limites.
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la pregunta es correcta o no.
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                // se activa la ventana que comprueba la respuesta en la UI.
                AnswerContainer.SetActive(true);

                // Se revisa si la respuesta es correcta o no es correcta.
                if (isCorrect)
                {
                    //Se obtienen el componente de la imagen para poder cambiarlo a verde, esto indica que es correcto.
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //Se actualiza con un arreglo el texto que indica si es correcto o no.
                    textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                }
                else
                {
                    //Se obtienen el componente de la imagen para poder cambiarlo a rojo, esto indica que es incorrecto.
                    AnswerContainer.GetComponent<Image>().color = Red;
                    textGood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
                }

                // Incrementamos el indice de la pregunta actual para que no se repita la pregunta actual.
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

    //Función que asigna la respuesta del player a un valor Int para poder ser evaluada en LoadQuestion
    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    //Metodo que checa si el jugador está interactuando con los botones.
    //Ejemplo: se usa if´para poder como condicion si la respuesta del player no es igual a 9 (answerFromPlayer != 9) se cumple la condición de que puede interactuar con el.
    public bool CheckPlayerState()
    {
        // Checamos que al interactuar con los botones, estos cambien de color al ser seleccionados.
        if (answerFromPlayer != 9)
        {
            // Si no se interactua se pondra de color gris :3
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return true;
        }
        else
        {
            // Si no sí interactua se pondra de color blanco :3
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.white;
            return false;
        }
    }
}
