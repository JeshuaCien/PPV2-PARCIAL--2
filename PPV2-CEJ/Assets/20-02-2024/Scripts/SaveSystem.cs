using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;

    public Subject data;
    public SubjectContainer subject;


    //Singleton-está función asegura que solo exista una instancia de la clase
    //durante el ciclo de vida de la aplicación. Si se intenta crear
    //una segunda instancia, simplemente se devuelve la instancia existente en lugar
    //de crear una nueva. Esto es útil en situaciones donde solo se necesita una única
    //instancia de una clase para ser compartida entre diferentes partes del código.
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

    private void Start()
    {
        SaveToJSON("LeccionYeah", data);
        //
        subject = LoadFromJSON<SubjectContainer>("SubjectYeah");
    }

    /// <summary>
    /// Está funcion esta encargada de almacenar objetos en aechivos JSON.
    /// </summary>
    /// <param name="_fileName"></param>
    /// <param name="_data"></param>

    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSON_data = JsonUtility.ToJson(_data, true);

            if (JSON_data.Length != 0)
            {
                Debug.Log("JSON STRING : " + JSON_data);
                string filename = _fileName + ".Json";
                string filePath = Path.Combine(Application.dataPath + "/Resources/JSONS/", filename);
                File.WriteAllText(filePath, JSON_data);
                Debug.Log("JSON almacenando en la dirección : " + filePath);
            }
            else
            {
                Debug.Log("Error - fileSystem: JSON_data is empty, check for local variable [string JSON_data]");
            }
        }
        else
        {
            Debug.LogWarning("Error: _Data is null, checa el parametro [object _data]");
        }
    }

    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        T Dato = new T();
        string path = Application.dataPath + "/Resources/JSONS/" + _fileName + ".json";
        string JSON_data = "";
        if (File.Exists(path))
        {
            JSON_data = File.ReadAllText(path);
            Debug.Log("JSON STRING: " + JSON_data);
        }
        if (JSON_data.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSON_data, Dato);
        }
        else
        {
            Debug.LogWarning("ERROR _ FyleSystem: JSON_data is empty, check for local variable [string JSON_data]");
        }
        return Dato;
    }

}
