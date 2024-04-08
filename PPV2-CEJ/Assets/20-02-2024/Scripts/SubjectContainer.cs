using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*/  Este atributo es una anotación que indica al sistema de serialización de Unity que esta 
 * clase puede ser serializada. Esto significa que los objetos de esta clase pueden ser convertidos 
 * a un formato de datos que puede ser almacenado en disco o transmitido a través de la red, como JSON. /*/
[System.Serializable] 


public class SubjectContainer
{
    //El header es un atributo que permite mostrar en el inspector un titulo el cual adjunta variables para un mejor orden.
    [Header("GameObject Configuration")]

    /*/Este atributo indica que las variables siguientes deben ser serializadas, 
     * lo que permite que sus valores se muestren en el Inspector de Unity 
     * y se guarden cuando se guarda el GameObject al que está adjunta esta clase. /*/
    [SerializeField]

    //Variable que indica el numer de lección.
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    [SerializeField]

    //Lista creada para guardar dentro de ella las lecciones.
    public List<Subject> leccionList;
}