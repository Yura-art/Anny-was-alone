using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicatorController : MonoBehaviour
{
    public GameObject[] characters;  // Lista de personajes en la escena
    public GameObject arrow;         // Referencia a la flecha
    private int currentCharacterIndex = 0; // Índice del personaje activo

    void Start()
    {
        // Posicionar la flecha sobre el personaje inicial
        UpdateArrowPosition();
    }

    void Update()
    {
        // Cambiar de personaje cuando se presione la tecla "F"
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeCharacter();
        }

        // Mantener la flecha sobre el personaje activo
        UpdateArrowPosition();
    }

    void ChangeCharacter()
    {
        // Cambiar al siguiente personaje
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Length;
        UpdateArrowPosition();
    }

    void UpdateArrowPosition()
    {
        // Posicionar la flecha sobre el personaje activo sin cambiar la escala
        if (arrow != null && characters[currentCharacterIndex] != null)
        {
            // Obtener la posición del personaje actual
            Vector3 characterPosition = characters[currentCharacterIndex].transform.position;
            float characterHeight = characters[currentCharacterIndex].GetComponent<Renderer>().bounds.size.y;

            // Ajustar la posición de la flecha justo encima del personaje
            Vector3 arrowPosition = new Vector3(characterPosition.x, characterPosition.y + characterHeight + 0f, characterPosition.z);

            // Asignar la nueva posición a la flecha
            arrow.transform.position = arrowPosition;

            // Mantener la escala original de la flecha
            arrow.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
}