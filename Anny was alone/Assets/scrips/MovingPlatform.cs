//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MovingPlatform : MonoBehaviour
//{
//    // Velocidad de la plataforma
//    public float moveSpeed = 2f;

//    // Posiciones l�mite entre las cuales la plataforma se mover�
//    public Vector2 topPosition = new Vector2(-1.6f, -15.4f);
//    public Vector2 bottomPosition = new Vector2(-1.6f, -2.8f);

//    // Direcci�n de movimiento (1 = subiendo, -1 = bajando)
//    private int direction = -1;

//    void Update()
//    {
//        // Mueve la plataforma en la direcci�n actual
//        transform.Translate(Vector2.up * direction * moveSpeed * Time.deltaTime);

//        // Cambia la direcci�n si la plataforma llega a las posiciones l�mite
//        if (direction == 1 && transform.position.y >= topPosition.y)
//        {
//            direction = -1;
//        }
//        else if (direction == -1 && transform.position.y <= bottomPosition.y)
//        {
//            direction = 1;
//        }

//        // Asegura que la plataforma mantenga la posici�n x fija
//        transform.position = new Vector2(topPosition.x, transform.position.y);
//    }
//}

