using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CambioNivel : MonoBehaviour
{
    public int idPlayer;
    private LevelDetector manager;
    private bool Door = false;

    void Start()
    {

        manager = FindObjectOfType<LevelDetector>();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        Movimiento movimiento = otro.GetComponent<Movimiento>();
        if (movimiento != null && movimiento.idPlayer == idPlayer && !Door)
        {
            Door = true;  // Marcar como alcanzada
            if (manager != null)
            {
                manager.JugadorLlegadoAMeta(idPlayer);
            }
        }
    }

    void OnTriggerExit2D(Collider2D otro)
    {
        Movimiento movimiento = otro.GetComponent<Movimiento>();
        if (movimiento == null || movimiento.idPlayer != idPlayer || Door)
        {
            return;
        }
        Door = false;  // Marcar como no alcanzada
        if (manager != null)
        {
            manager.JugadorSalioDeMeta(idPlayer);
        }
    }

}
