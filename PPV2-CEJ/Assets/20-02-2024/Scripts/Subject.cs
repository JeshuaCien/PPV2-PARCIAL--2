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

    //Clase la cual se usa para poder acceder a sus variables desde Leccion la cual se encarga de crear scriptable objects que se crean con está plantilla.
}

