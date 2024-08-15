using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    float horizontal;
    Rigidbody2D rigido;
    private BoxCollider2D cajaColision;

    public int idPlayer;

    public float jumpForce;
    public float moveSpeed;

    public Transform detectionCenter;
    public Vector2 scaleDetection;
    public LayerMask capaDetectionPlayer;
    public LayerMask capaDeteccionFlour;

    public bool touchFlour;
    public bool touchPlayer;

    public bool On = false;

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
        touchFlour = Physics2D.OverlapBox(detectionCenter.position, scaleDetection, 0, capaDeteccionFlour);
        touchPlayer = Physics2D.OverlapBox(detectionCenter.position, scaleDetection, 0, capaDetectionPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (On)
        {
            EstaEnSuelo();

            horizontal = Input.GetAxis("Horizontal");

            rigido.velocity = new Vector2(horizontal * moveSpeed, rigido.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && (touchFlour || touchPlayer))
            {
                rigido.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    public void ActivarSalto(bool habilitar)
    {
        On = habilitar;

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
        Gizmos.DrawWireCube(detectionCenter.position, scaleDetection);
    }

    public void Reaparecer()
    {
        transform.position = spawn;
        rigido.velocity = new Vector2(0, 0);
    }
}

