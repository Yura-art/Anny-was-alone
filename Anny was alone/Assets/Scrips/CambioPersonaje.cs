using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPersonaje : MonoBehaviour
{
    public List<GameObject> listaDePersonajes = new List<GameObject>();

    public int jugadorActivo;

    // Start is called before the first frame update
    void Start()
    {
        ActivarPersonaje();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SiguientePersonaje();
            ActivarPersonaje();
        }
    }

    void SiguientePersonaje()
    {
        jugadorActivo++;
        if (jugadorActivo > listaDePersonajes.Count - 1)
        {
            jugadorActivo = 0;
        }
    }

    void ActivarPersonaje()
    {
        for (int i = 0; i < listaDePersonajes.Count; i++)
        {
            if (i == jugadorActivo)
            {
                listaDePersonajes[i].gameObject.GetComponent<Movimiento>().ActivarSalto(true);
            }
            else
            {
                listaDePersonajes[i].gameObject.GetComponent<Movimiento>().ActivarSalto(false);
            }
        }
    }
}
