using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leccion1
{
    public int ID;
    public string lessons;
    public List<string> options;
    public int correctAnswer;

}

[CreateAssetMenu(fileName = "New Lesson", menuName = "ScriptableObject/NeeLesson", order = 1)]

public class Leccion : ScriptableObject
{
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Leccion1> leccionList;
}
