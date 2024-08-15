using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    // Define el color original y el nuevo color al que cambiará la puerta
    public Color originalColor = Color.white;
    public Color triggeredColor = Color.green;

    // Referencia al SpriteRenderer de la puerta
    private SpriteRenderer spriteRenderer;

    // Nombre o índice de la siguiente escena
    public int nextSceneIndex;

    void Start()
    {
        // componente SpriteRenderer del objeto puerta
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Establece el color original
        spriteRenderer.color = originalColor;
    }

    // Detecta cuando el personaje (Yura) entra en la puerta
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica que sea el personaje el que colisiona
        if (other.gameObject.CompareTag("Player"))
        {
            // Cambia el color de la puerta
            spriteRenderer.color = triggeredColor;

            // Cambia a la siguiente escena después de un pequeño retardo
            Invoke("LoadNextScene", 1f);  // El retardo es opcional; aquí se usa 1 segundo
        }
    }

    void LoadNextScene()
    {
        // Cambia a la escena especificada por el índice
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Detecta cuando el personaje sale de la puerta y restaura el color original
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Restaura el color original
            spriteRenderer.color = originalColor;

            // Cancela el cambio de escena si el personaje sale de la puerta antes del retardo
            CancelInvoke("LoadNextScene");
        }
    }
}
