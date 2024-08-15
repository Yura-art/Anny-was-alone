using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioNivel : MonoBehaviour
{
    public int idJugador;
    private DetectorNiveles manager;
    private bool meta = false;

    void Start()
    {

        manager = FindObjectOfType<DetectorNiveles>();
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
        }
    }
}
