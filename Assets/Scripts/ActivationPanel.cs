using UnityEngine;
using UnityEngine.InputSystem;

public class ActivationPanel : MonoBehaviour
{
    [SerializeField] private DoorController puerta;

    private bool jugadorDentro = false;

    // Update is called once per frame
    void Update()
    {
        if(jugadorDentro && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (puerta.Abierta)
            {
                puerta.Cerrar();
            }
            else
            {
                puerta.Abrir();
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            jugadorDentro = false;
        }
    }
}
