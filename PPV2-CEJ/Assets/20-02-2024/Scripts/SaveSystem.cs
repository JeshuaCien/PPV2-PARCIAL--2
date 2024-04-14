using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public Subject data;
    public SubjectContainer subject;
    
    public static SaveSystem Instance;


    //Singleton-está función asegura que solo exista una instancia de la clase
    //durante el ciclo de vida de la aplicación. Si se intenta crear
    //una segunda instancia, simplemente se devuelve la instancia existente en lugar
    //de crear una nueva. Esto es útil en situaciones donde solo se necesita una única
    //instancia de una clase para ser compartida entre diferentes partes del código.
    private void Awake()
    {
        /*/Esta línea comprueba si ya existe una instancia de SaveSystem.
        Si ya existe, simplemente se sale, lo que significa que no se crea una nueva instancia./*/
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

    //Método usada para ser llamada en el primer frame para poder llamar a dos funciones que cargan información tipo JSON.
    private void Start()
    {
        // Función que llama desde el inicio a la función SaveToJSON
        // la cual guarda el nombre del dato (LeccionYeah) y el tipo de dato.
        SaveToJSON("LeccionYeah.json", data);


        // Además de llamar a subject que se encarga de cargar datos de la fución
        // LoadFromJSON a el tipo de objeto donde se guardara SubjectContainer.
        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }

    /// <summary>
    /// Está funcion esta encargada de almacenar objetos en aechivos JSON.
    /// </summary>
    /// <param name="_fileName"></param>
    /// <param name="_data"></param>

    // Este método toma dos argumentos: _fileName, que es el nombre del archivo en el que se guardará el JSON,
    // y _data, que es el objeto que se convertirá a JSON y se guardará en el archivo.
    public void SaveToJSON(string _fileName, object _data)
    {
        /*/Se comprueba que el objeto _data no sea nulo para saber si existe un tipo de dato que guardar. /*/
        if (_data != null)
        {
            /*/Aquí se convierte el objeto _data a una representación JSON utilizando ToJson de la clase JsonUtility. 
            * El segundo argumento true indica que el JSON resultante se formateará para una mejor legibilidad.  /*/
            string JSON_data = JsonUtility.ToJson(_data, true);

            /*/Se verifica si el JSON generado tiene contenido.
            * Esto con la finalidad de saber que se tenga un dato que guardar y no falle el codigo./*/
            if (JSON_data.Length != 0)
            {
                //Se manda un mensaje el cual indica que JSON string tiene la información de JSON_data imprimiendo en la consola la información.
                Debug.Log("JSON STRING : " + JSON_data);

                /*/Se crea el nombre del archivo concatenando(Uniendo dos o más cadenas de texto en una sola) _fileName 
              * con la extensión .Json. /*/
                string filename = _fileName + ".Json";

                /*/Aquí se construye la ruta completa del archivo donde se guardará el JSON. 
                 * Path.Combine se usa para que se pueda mandar bien la informaciím en idferentes sistemas operativos./*/
                string filePath = Path.Combine(Application.dataPath + "/StreamingAssets/JSONS/", filename);

                /*/Finalmente, el JSON se escribe en el archivo especificado, 
                 * utilizando File.WriteAllText el cual escribe toda la información almacenada./*/
                File.WriteAllText(filePath, JSON_data);

                /*/Mensaje que se manda para poder indicar que se guardo la información 
                 * en la variale filePath la cual indica las carpetas donde se guardan./*/
                Debug.Log("JSON almacenando en la dirección : " + filePath);
            }
            //Sí no se tiene un contenido, se emite un mensaje de error indicando que no hay datos para guardar.
            else
            {
                Debug.Log("Error - fileSystem: JSON_data is empty, check for local variable [string JSON_data]");
            }
        }
        //Sí no se tiene un contenido, se emite un mensaje de error indicando que no hay datos para guardar.
        else
        {
            Debug.LogWarning("Error: _Data is null, checa el parametro [object _data]");
        }
    }

    /*/Método es genérico, lo que significa que puede cargar datos y devolver un objeto de cualquier tipo.
    * Se toma _fileName el cual es el nombre del archivo JSON que se cargará.
    * devuelve un objeto de tipo T (Template), una plantilla.
   /*/
    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        /*/Se crea una nueva instancia del tipo genérico T. 
         * Esta instancia se utilizará para almacenar los datos deserializados del archivo JSON. /*/
        T Dato = new T();

        /*/Se construye la ruta completa del archivo JSON que se va a cargar. /*/
        string path = Application.dataPath + "/StreamingAssets/JSONS/" + _fileName + ".json";
        
        /*/Se inicializa una cadena vacía para almacenar los datos JSON leídos del archivo. 
         * Esto pra actualizar la misma cadena. /*/
        string JSON_data = "";

        /*/Se verifica si el archivo JSON especificado existe en la ruta proporcionada./*/
        if (File.Exists(path))
        {
            /*/Se verifica si el archivo JSON especificado existe en la ruta proporcionada./*/
            JSON_data = File.ReadAllText(path);

            /*/Se manda un mensaje el cual indica que JSON string 
            * tiene la información de JSON_data imprimiendo en la consola la información. /*/
            Debug.Log("JSON STRING: " + JSON_data);
        }
        /*/Se comprueba si la cadena JSON tiene contenido./*/
        if (JSON_data.Length != 0)
        {

            /*/Aquí se deserializa la cadena JSON en el objeto Dato utilizando FromJsonOverwrite de JsonUtility. 
            * Este método sobrescribe los valores de Dato con los valores deserializados del JSON.
            * 
            * FromJsonOverwrite (reconstruye un objeto a partir del formulario serializado.)/*/
            JsonUtility.FromJsonOverwrite(JSON_data, Dato);
        }

        // Si está vacía, se emite una advertencia indicando que no hay datos en el archivo.
        else
        {
            Debug.LogWarning("ERROR _ FyleSystem: JSON_data is empty, check for local variable [string JSON_data]");
        }
        /*/El método devuelve el objeto Dato deserializado. /*/
        return Dato;
    }

}
