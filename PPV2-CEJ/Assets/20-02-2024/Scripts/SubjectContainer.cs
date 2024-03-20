using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubjectContainer
{
    //Subject container se encarga de acceder a la información del archivo JSON
    //el cual nosostros usamos como contenedor.
    [Header("GameObject Configuration")]
    [SerializeField]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    [SerializeField]
    public List<Subject> leccionList;
}