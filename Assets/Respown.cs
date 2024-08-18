using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {

        Rigidbody2D rb = colision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }


        ReiniciarNivel();
    }

    void ReiniciarNivel()
    {

        string escenaActual = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(escenaActual);
    }
}
