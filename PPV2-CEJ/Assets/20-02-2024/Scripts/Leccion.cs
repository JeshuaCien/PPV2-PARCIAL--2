using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/Este atributo se coloca encima de la definici�n de la clase Leccion. 
 * Proporciona informaci�n a Unity sobre c�mo debe aparecer el men� contextual en el editor de Unity 
 * para crear nuevos objetos de scriptable de esta clase. 
 * 
 * fileName: Especifica el nombre predeterminado que se le dar� al archivo del scriptable cuando se cree uno nuevo.
 * 
 * menuName: Define la ruta en el men� del editor de Unity donde aparecer� la opci�n para crear un nuevo objeto de 
 * scriptable. En este caso, aparecer� en el men� "Assets" bajo la subcarpeta "Create/ScriptableObject/NewLesson".
 * 
 * order: Indica el orden en el que aparecer� esta opci�n en relaci�n con otras opciones de creaci�n de scriptables en el men�.
 * 
 * El atributo [CreateAssetMenu] personaliza c�mo se crea un nuevo objeto de scriptable de esta clase en el editor de Unity.
 * /*/
[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]


/*/Los scriptable objects son objetos que almacenan datos en un archivo asset en el proyecto de Unity
 * y son �tiles para almacenar datos que no est�n asociados a instancias espec�ficas del juego, 
 * como configuraciones, estad�sticas, di�logos, etc./*/

//Define la clase Leccion como un scriptable object en Unity.
public class Leccion : ScriptableObject
{
    //El header es un atributo que permite mostrar en el inspector un titulo el cual adjunta variables para un mejor orden.
    [Header("GameObject Configuration")]
    //Esta es una variable p�blica que parece representar el n�mero de lecci�n actual.
    public int Lesson = 0;


    [Header("Lesson Quest Configuration")]
    //Esta es una lista p�blica de objetos de tipo Subject.
    public List<Subject> leccionList;
}