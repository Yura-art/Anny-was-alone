using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDetector : MonoBehaviour
{
    public string escena;
    private HashSet<int> playersOnDoor = new HashSet<int>();
    private int allPlayers;

    void Start()
    {

        allPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    public void JugadorLlegadoAMeta(int idJugador)
    {
        if (!playersOnDoor.Contains(idJugador))
        {
            playersOnDoor.Add(idJugador);
        }


        if (playersOnDoor.Count >= allPlayers)
        {
            CambiarEscena();
        }
    }

    public void JugadorSalioDeMeta(int idJugador)
    {
        if (playersOnDoor.Contains(idJugador))
        {
            playersOnDoor.Remove(idJugador);
        }
    }

    private void CambiarEscena()
    {

        SceneManager.LoadScene(escena);
    }
}
