using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]

public class Leccion : ScriptableObject
{
    //Scriptable object que sirve para poder crear una lección la
    //cual hereda información y puede ser alterada sin mover el codigo madre que es este mismo.

    //Codigo que se hereda.
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Subject> leccionList;
}