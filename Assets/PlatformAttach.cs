using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Convertir al personaje en hijo de la plataforma cuando aterriza en ella
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Método llamado cuando el personaje sigue colisionando con la plataforma
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Mantener al personaje como hijo mientras está sobre la plataforma
            collision.gameObject.transform.SetParent(transform);
        }
    }

    // Método llamado cuando el personaje deja de colisionar con la plataforma
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Quitar al personaje como hijo de la plataforma cuando se va de ella
            collision.gameObject.transform.SetParent(null);
        }
    }
}