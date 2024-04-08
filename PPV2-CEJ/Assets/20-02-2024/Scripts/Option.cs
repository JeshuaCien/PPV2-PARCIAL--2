using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID;
    public string OptionName;

    /*/ Cuando se pone este script en un boton el cual tiene como child un texto, está linea de codigo podrá obtener esa variable
         y actualizarla dependiendo de lo que se necesite. /*/

    //Metodo start para poder inicializar desde el primer frame y así obtener o acceder desde el inicio recursos y variables.
    void Start()
    {
        //Se obtiene y establece a (OptionName) desde el Start para que se tenga acceso a el sin que ocurra un error.
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    /*/Método que sirve para actualizar el texto que se encuentra en los botones de las opciones en la escena de la leccion.
     * Esto se realizo para poder ver el nombre de las respuestas seleccionabes.
   /*/
    public void UpdateText()
    {
        // Se obtiene el componente children el cual tiene el texto para
        // ser actualizado al de las listas del scriptable object
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Metodo creado para ser llamado dese el botón de la UI el cual tendra una condicion que al presionar una respuesta,
    // se llame a las dos funciones que asignan el Id de la respuesta y comprueba si la respuesta es correcta.
    public void SelectOption()
    {
        //Se asigna la respuesta correcta llamando al script LevelManager haciendo una instancia de el metodo SetPlayerAnswer.
        LevelManager.Instance.SetPlayerAnswer(OptionID);

        //Se comprueba con la funcion llamada del levelmanager CheckPlayerState la cual checa el estado del botón si fue seleconado o no.
        LevelManager.Instance.CheckPlayerState();
    }
}
