using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorNiveles : MonoBehaviour
{
    public string escena;
    private HashSet<int> jugadoresEnMeta = new HashSet<int>();
    private int totalJugadores;

    void Start()
    {

        totalJugadores = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    public void JugadorLlegadoAMeta(int idJugador)
    {
        if (!jugadoresEnMeta.Contains(idJugador))
        {
            jugadoresEnMeta.Add(idJugador);
        }


        if (jugadoresEnMeta.Count >= totalJugadores)
        {
            CambiarEscena();
        }
    }

    public void JugadorSalioDeMeta(int idJugador)
    {
        if (jugadoresEnMeta.Contains(idJugador))
        {
            jugadoresEnMeta.Remove(idJugador);
        }
    }

    private void CambiarEscena()
    {

        SceneManager.LoadScene(escena);
    }
}
