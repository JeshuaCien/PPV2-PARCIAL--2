using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    //Se obtiene el componente TMP del texto para poder actualizarlo
    //al texto que tiene la pregunta en el scriptable object.
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Función que actualiza el texto.
    public void UpdateText()
    {
        // Se obtiene el componente children el cual tiene el texto para
        // ser actualizado al de las listas del scriptable object
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    // Función que checa que se selecione una opcion y se llaman a dos fuunciones
    // del script levelManager.
    public void SelectOption()
    {
        //Se asigna la respuesta correcta en función del ID que se encuentraen el script Subject.
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        //Se comprueba con la funcion llamada del levelmanager se selecione una rerspuesta y se cheque si
        //los botones son interactuables.
        LevelManager.Instance.CheckPlayerState();
    }
}
