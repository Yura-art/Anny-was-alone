using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarObjeto : MonoBehaviour
{
    public GameObject objeto;
    public int idJugadorPermitido;

    private void OnCollisionEnter2D(Collision2D colision)
    {
        Movimiento movimiento = colision.gameObject.GetComponent<Movimiento>();

        if (movimiento != null && movimiento.idJugador == idJugadorPermitido)
        {
            objeto.SetActive(false);
        }
    }
}
