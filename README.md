# Proyecto que se basa en la creación de una Lección de Duolingo el cual se puede seleccionar una respuesta y comprobar si está mal o bien. #
---
## *Repositorio (PPV2-PARCIAL--2) Creado por Jeshua Cienfuegos Estrada.* ##
***
 ### **Principales características:** ###
 
 + Se presentan 5 preguntas en una lección.
 
 + Se presentan 5 posibles opciones para responder a la pregunta.
 
 + Se evalúa la opción que se seleccione.
 
 + Se pasa a la siguiente pregunta.

 + Se visualiza un mensaje de correcto o incorrecto.

---
### Modo de uso: ###
+ Se presenta el menu el cual tiene botones amarillos- al señecionarlos se abre una ventana la cual tiene un botón, si se presiona, se inicira la lección.
  
+ Aparecera una ventana con una pregunta en la parte superior, se puede seleccionar cualquiera de los botones amarillos presentes en está misma ventana, al seleccionarse se abrirá una ventana para ir a las preguntas.

+ Al selecionar una opción se va a oscurecer el botón de coprobar, el cual debe de ser presionado.

+ Se evalua la opcion, para después mostrar un mensaje si es correcta o no.

+ despues de un par de segundos, cambiará la pregunta y se deberá de selecionar otra respuesta.

+ Al final de las preguntas ya no se podra elegir el botón comprobar, por lo que se deberá de apretar la tecla de espacio (Space Bar) y lo mandará al menu para repetir los pasos anteriores.
---
### ` Código ` ###
> El código utilizado en este preoyecto es el lenguaje ` C# ` de programación moderno, basado en objetos y con seguridad de tipos. Tiene raíces en la familia de lenguajes C.
> C# es un lenguaje orientado a objetos.
>Todos los cripts están mejor explicados en el proyecto con comentarios.

Se basa en 6 scripts los cuales son:
---
+ Subject: Se creo este scrip para poder acceder a sus bariables y lista en level manager.
`public int ID;
 public string lessons;
 public List<string> options;
 public int correctAnswer;  `
---
+ Option. Es un script el cual obtiene el componente de texto en la función Start(), actualiza el texto en la función UpdateText() y define la opcion correcta en SelectOption().
   ` public int OptionID;
     public string OptionName;
   void Start()
{
transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
}
public void UpdateText()
{
transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
}
public void SelectOption()
{
LevelManager.Instance.SetPlayerAnswer(OptionID);
LevelManager.Instance.CheckPlayerState();
}`
---
+ LevelManager. Contiene diferentes variables y un header que ordena las variables dependiendo de lo que se necesite.
`public static LevelManager Instance;
 [Header("Level Data")]
 public Leccion Lesson;
`
`[Header("User interface")]
 public TMP_Text textQuestion;
 public TMP_Text textGood;
 public List<Option> Question;
 public GameObject CheckButton;
 public GameObject AnswerContainer;
 public Color Green;
 public Color Red;
`
`[Header("Game Configuration")]
 public int questionAmount = 0;
 public int currentQuestion = 0;
 public string question;
 public string correctAnswer;
 public int answerFromPlayer = 9;
`
` [Header("Current Lesson")]
 public Subject currentLesson;
`
---
+ Se creo un singleton el cual es para restringir la creación de objetos pertenecientes a este script.
`  private void Awake()
  {
      if (Instance != null)
      {
          return;
      }
      else
      {
          Instance = this;
      }
  }`
---
+ Función start obtiene las preguntas de la leccion utilizando la bariable del script leccion, llama la función LoadQuestion(); que actualiza la pregunta y sus opciones. CheckPlayerState(); se llama para evaluar las respuestas.
`void Start()
 {
  questionAmount = Lesson.leccionList.Count;
  LoadQuestion();
  CheckPlayerState();
 }`
---
+ Funcion loadquestion el cual carga las opciones asegurandose que este dentro del rango de opciones, establece la respuesdta correcta y manda un mensaje al terminar de recorer todas las opciones.
`private void LoadQuestion()
{if (currentQuestion < questionAmount)
 {
  currentLesson = Lesson.leccionList[currentQuestion];
  question = currentLesson.lessons;
  correctAnswer = currentLesson.options[currentLesson.correctAnswer];
  textQuestion.text = question;
  for (int i = 0; i < currentLesson.options.Count; i++)
   {
    Question[i].GetComponent<Option>().OptionName = currentLesson.options[i];
    Question[i].GetComponent<Option>().OptionID = i;
    Question[i].GetComponent<Option>().UpdateText();
   }
   }
   else
   {Debug.Log("Fin de las preguntas");
   }
   }`
---
+ Funcioón que nos manda a la siguiente pregunta.
`public void NextQuestion()
 {
 if (CheckPlayerState())
 {
 if (currentQuestion < questionAmount)
 { 
 bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;
 AnswerContainer.SetActive(true);
 if (isCorrect)
 {
 AnswerContainer.GetComponent<Image>().color = Green;
 textGood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
  }
   else
  {
  AnswerContainer.GetComponent<Image>().color = Red;
  textGood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
  }
  currentQuestion++;
  StartCoroutine(ShowResultAndLoadQuestion(isCorrect));   
  answerFromPlayer = 9;    
  }
  else
  {
   //Cambio la escena
  }
  }}`
---
+ Función que inicia una corrutina la cual suspende el proceso del codigo dependiendo lo que se especifique dentro de está misma función.
`private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
{
yield return new WaitForSeconds(2.5f);
AnswerContainer.SetActive(false);
LoadQuestion();
CheckPlayerState();
}`
---
+ Función SetPlayerAnswer(); para establecer la opción que selecione el jugador y CheckPlayerState(); para poder ver si el jugador interactuo con un botón de las opciones.
` public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }
    public bool CheckPlayerState()
    {
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
        }}}`
---
+ LessonContainer.
+ Leccion y CambiarLesso.
---
#### Intalación del proyecto ####
 + 1.- Se debe de acceder al repositorio PPV2-PARCIAL--2 y presionar el botón " <> Code".
 
 + 2.- Se abrirá una ventana donde se seleccionará la opción que dice "Download ZIP" y se descargara un Zip.
 
 + 3.- Localizar el zip para descomprimirlo, por consiguiente, se debe de abrir la capeta que lleva el mismo nombre que el repositorio.

##### Para abrir el ejecutable #####
+ 4.- Se abre la carpeta que tiene nombre "Ejecutable-Lesson". 
 
+ 5.- Se debe de abrir un archivo que tiene el Icon de Cofre.

##### Para abrir el proyecto en unity ##### 

 + 4.- Se debe de entrar en la carpeta del paso anterior y van a aparecer 3 carpetas adicionales de las cuales se debe de seleccionar la carpeta "Assets". 
 
 + 5.- Una vez dentro de los Assets se debe seleccionar la carpeta "Scenes", dentro de esta carpeta se tendrá el Lesson (Nombre de la escena) del inventario, dar clic en el símbolo de UNITY Y se abrirá en su Unity. 
 
 + 6.- Si no funciono, en UNITY HUB se seleccionará la opción "ADD" y se seleccionará la opción "add Project from disk" después se debe de buscar la carpeta del proyecto que se llama "PPV2-CEJ"- se selecciona y se da aceptar para abrir el proyecto.

##### se subió un video en Teams donde se muestra el funcionamiento del proyecto. #####

