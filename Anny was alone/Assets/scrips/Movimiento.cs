using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigido;
    private BoxCollider2D cajaColision;

    public int idJugador;

    public float fuerzaSalto;
    public float velocidad;

    public Transform centroDeteccion;
    public Vector2 tamanoDeteccion;
    public LayerMask capaDeteccionJugador;
    public LayerMask capaDeteccionPiso;

    public bool tocaPiso;
    public bool tocaJugador;

    public bool activar = false;

    Vector2 spawn;

    // Start is called before the first frame update
    void Awake()
    {
        rigido = GetComponent<Rigidbody2D>();
        cajaColision = GetComponent<BoxCollider2D>();

        spawn = transform.position;
    }

    void EstaEnSuelo()
    {
        tocaPiso = Physics2D.OverlapBox(centroDeteccion.position, tamanoDeteccion, 0, capaDeteccionPiso);
        tocaJugador = Physics2D.OverlapBox(centroDeteccion.position, tamanoDeteccion, 0, capaDeteccionJugador);
    }

    // Update is called once per frame
    void Update()
    {
        if (activar)
        {
            EstaEnSuelo();

            horizontal = Input.GetAxis("Horizontal");

            rigido.velocity = new Vector2(horizontal * velocidad, rigido.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && (tocaPiso || tocaJugador))
            {
                rigido.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
        }
    }

    public void ActivarSalto(bool habilitar)
    {
        activar = habilitar;

        if (habilitar)
        {
            rigido.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigido.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(centroDeteccion.position, tamanoDeteccion);
    }

    public void Reaparecer()
    {
        transform.position = spawn;
        rigido.velocity = new Vector2(0, 0);
    }
}