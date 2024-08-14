using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject characterA; // El primer personaje
    public GameObject characterB; // El segundo personaje
    public Cinemachine.CinemachineVirtualCamera vcamA; // Virtual Camera para characterA
    public Cinemachine.CinemachineVirtualCamera vcamB; // Virtual Camera para characterB

    private bool isControllingA = true; // Empieza controlando al personaje A

    void Start()
    {
        // Inicialmente, la cámara sigue a characterA
        vcamA.Priority = 10;
        vcamB.Priority = 5;
    }

    void Update()
    {
        // Cambiar de personaje al presionar la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Cambiar el estado de control
        isControllingA = !isControllingA;

        if (isControllingA)
        {
            // Controla characterA y ajusta la cámara
            characterA.GetComponent<moviemitno>().enabled = true;
            characterB.GetComponent<moviemitno>().enabled = false;

            vcamA.Priority = 10;
            vcamB.Priority = 5;
        }
        else
        {
            // Controla characterB y ajusta la cámara
            characterA.GetComponent<moviemitno>().enabled = false;
            characterB.GetComponent<moviemitno>().enabled = true;

            vcamA.Priority = 5;
            vcamB.Priority = 10;
        }
    }
}