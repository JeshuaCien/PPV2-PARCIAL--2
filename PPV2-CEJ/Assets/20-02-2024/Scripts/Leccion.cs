using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/Este atributo se coloca encima de la definición de la clase Leccion. 
 * Proporciona información a Unity sobre cómo debe aparecer el menú contextual en el editor de Unity 
 * para crear nuevos objetos de scriptable de esta clase. 
 * 
 * fileName: Especifica el nombre predeterminado que se le dará al archivo del scriptable cuando se cree uno nuevo.
 * 
 * menuName: Define la ruta en el menú del editor de Unity donde aparecerá la opción para crear un nuevo objeto de 
 * scriptable. En este caso, aparecerá en el menú "Assets" bajo la subcarpeta "Create/ScriptableObject/NewLesson".
 * 
 * order: Indica el orden en el que aparecerá esta opción en relación con otras opciones de creación de scriptables en el menú.
 * 
 * El atributo [CreateAssetMenu] personaliza cómo se crea un nuevo objeto de scriptable de esta clase en el editor de Unity.
 * /*/
[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]


/*/Los scriptable objects son objetos que almacenan datos en un archivo asset en el proyecto de Unity
 * y son útiles para almacenar datos que no están asociados a instancias específicas del juego, 
 * como configuraciones, estadísticas, diálogos, etc./*/

//Define la clase Leccion como un scriptable object en Unity.
public class Leccion : ScriptableObject
{
    //El header es un atributo que permite mostrar en el inspector un titulo el cual adjunta variables para un mejor orden.
    [Header("GameObject Configuration")]
    //Esta es una variable pública que parece representar el número de lección actual.
    public int Lesson = 0;


    [Header("Lesson Quest Configuration")]
    //Esta es una lista pública de objetos de tipo Subject.
    public List<Subject> leccionList;
}