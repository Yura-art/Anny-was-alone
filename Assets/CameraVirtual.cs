using UnityEngine;
using Cinemachine;

public class CamaraVirtual : MonoBehaviour
{
    public CinemachineVirtualCamera camaraVirtual;
    public GameObject[] personajes;

    private int indicePersonajeActual = 0;

    void Start()
    {

        ActualizarSeguimientoCamara();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CambiarPersonaje();
        }
    }

    void CambiarPersonaje()
    {

        indicePersonajeActual = (indicePersonajeActual + 1) % personajes.Length;


        ActualizarSeguimientoCamara();
    }

    void ActualizarSeguimientoCamara()
    {
        if (personajes.Length == 0) return;


        camaraVirtual.Follow = personajes[indicePersonajeActual].transform;
       // camaraVirtual.LookAt = personajes[indicePersonajeActual].transform;
    }
}