using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Velocidad de la plataforma
    public float moveSpeed = 2f;

    // Posiciones límite entre las cuales la plataforma se moverá
    public Vector2 topPosition = new Vector2(-4.12f, 1.05f);
    public Vector2 bottomPosition = new Vector2(-4f, -10.5f);

    // Dirección de movimiento (1 = subiendo, -1 = bajando)
    private int direction = -1;

    void Update()
    {
        // Mueve la plataforma en la dirección actual
        transform.Translate(Vector2.up * direction * moveSpeed * Time.deltaTime);

        // Cambia la dirección si la plataforma llega a las posiciones límite
        if (direction == 1 && transform.position.y >= topPosition.y)
        {
            direction = -1;
        }
        else if (direction == -1 && transform.position.y <= bottomPosition.y)
        {
            direction = 1;
        }

        // Asegura que la plataforma mantenga la posición x fija
        transform.position = new Vector2(topPosition.x, transform.position.y);
    }
}

