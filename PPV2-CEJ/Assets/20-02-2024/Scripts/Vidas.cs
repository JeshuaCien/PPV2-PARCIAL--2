using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Vidas : MonoBehaviour
{
    

    [HideInInspector]
    public float vidas;

    [HideInInspector]
    public TextMeshProUGUI textMesh;

    [Header("Game Over")]
    public GameObject Gover;


    //Se inicia desde el Start que las vidas del jugador son 5 y que textMesh ontiene el componente TextMeshProUGUI,
    //esto con la finalidad de ser actualizado en un futuro.
    private void Start()
    {
        vidas = 5f;
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    //Este método se llama para restar una vida al jugador. Decrementa el valor de vidas, actualiza el texto mostrando el número de vidas y
    //llama al método EnableWindowGover() para comprobar si el jugador se ha quedado sin vidas.
    public void RestarVida()
    {
      vidas--;
      textMesh.text = vidas.ToString();
        EnableWindowGover();
    }

    // Este método comprueba si el número de vidas ha llegado a cero.
    // Si es así, activa el GameObject Gover, lo que probablemente muestra la pantalla de Game Over.
    public void EnableWindowGover()
    {
        if (vidas == 0f)
        {

            Gover.SetActive(true);
        }
    }

}
