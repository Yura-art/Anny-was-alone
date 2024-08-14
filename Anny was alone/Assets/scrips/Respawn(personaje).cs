//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Colision : MonoBehaviour
//{
//    private void OnCollisionEnter2D(Collision2D colision)
//    {
//        // Detiene el movimiento del objeto que colisiona
//        Rigidbody2D rb = colision.gameObject.GetComponent<Rigidbody2D>();
//        if (rb != null)
//        {
//            rb.velocity = Vector2.zero;
//        }

//        // Reinicia el nivel actual
//        ReiniciarNivel();
//    }

//    void ReiniciarNivel()
//    {
//        // Obtiene el nombre de la escena actual
//        string escenaActual = SceneManager.GetActiveScene().name;

//        // Carga la escena actual nuevamente, reiniciando el nivel
//        SceneManager.LoadScene(escenaActual);
//    }
//}
