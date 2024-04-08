using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Subject
{
    public int ID;
    public string lessons;
    public List<string> options;
    public int correctAnswer;

    //Clase la cual se usa para poder acceder a sus variables, siendo esta una plantilla para poder ser heredada a levelManager.
}

