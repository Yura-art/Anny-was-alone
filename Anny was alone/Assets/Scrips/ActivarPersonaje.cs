using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject objetos;

    private void OnCollisionEnter2D(Collision2D colision)
    {
        Movimiento jugador = colision.gameObject.GetComponent<Movimiento>();

        if (jugador != null)
        {
            objetos.SetActive(true);
        }
    }
}
