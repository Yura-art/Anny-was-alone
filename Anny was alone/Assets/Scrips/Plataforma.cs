using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject[] puntos;
    public float velocidad = 2;
    int indice = 0;

    public GameObject[] PuntosDeRuta { get => puntos; set => puntos = value; }
    public GameObject[] PuntosDeRutaAlternativos { get => puntos; set => puntos = value; }

    void Update()
    {
        MoverPlataforma();
    }

    void MoverPlataforma()
    {
        if (Vector3.Distance(transform.position, puntos[indice].transform.position) < 0.1f)
        {
            indice++;
            if (indice >= puntos.Length)
            {
                indice = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, puntos[indice].transform.position, velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            colision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            colision.gameObject.transform.SetParent(null);
        }
    }
}
