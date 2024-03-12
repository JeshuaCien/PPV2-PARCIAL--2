using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Linea de código que se usa para poder trabajar con objetos prefabs
[System.Serializable]

public class Subject
{
    //Variables que se usaran en otros scripts y ayudaran a asignar las respuestas.
    public int ID;
    public string lessons;
    public List<string> options;
    public int correctAnswer;

}

