using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPlataforma : MonoBehaviour
{
    public GameObject objeto;
    public Plataforma plataforma;
    public int idJugadorPermitido;

    private void OnCollisionEnter2D(Collision2D colision)
    {
        Movimiento movimiento = colision.gameObject.GetComponent<Movimiento>();

        if (movimiento != null && movimiento.idJugador == idJugadorPermitido)
        {
            plataforma.enabled = true;
        }
    }
}
