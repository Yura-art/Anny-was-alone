using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioNivel : MonoBehaviour
{
    public int idJugador;
    private DetectorNiveles manager;
    private bool meta = false;

    // Agregar los colores
    public Color originalColor = Color.white;
    public Color triggeredColor = Color.green;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        manager = FindObjectOfType<DetectorNiveles>();
        // Inicializar el SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor; // Establecer el color original
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        Movimiento movimiento = otro.GetComponent<Movimiento>();
        if (movimiento != null && movimiento.idJugador == idJugador && !meta)
        {
            meta = true;  // Marcar como alcanzada
            if (manager != null)
            {
                manager.JugadorLlegadoAMeta(idJugador);
            }
            // Cambiar el color cuando el jugador llega
            if (spriteRenderer != null)
            {
                spriteRenderer.color = triggeredColor;
            }
        }
    }

    void OnTriggerExit2D(Collider2D otro)
    {
        Movimiento movimiento = otro.GetComponent<Movimiento>();
        if (movimiento != null && movimiento.idJugador == idJugador && meta)
        {
            meta = false;  // Marcar como no alcanzada
            if (manager != null)
            {
                manager.JugadorSalioDeMeta(idJugador);
            }
            // Restaurar el color cuando el jugador sale
            if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }
}
