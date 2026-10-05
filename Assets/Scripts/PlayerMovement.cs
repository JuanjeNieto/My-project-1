
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerRespawn playerRespawn;

    private Vector2 movimiento;

    public float fuerza = 12f;
    public float fuerzaSalto = 7f;
    public float distanciaSuelo = 1.1f;
    public float limiteCaida = -5f;

    private bool enSuelo;
    private bool quiereSaltar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerRespawn = GetComponent<PlayerRespawn>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float x = 0f;
        float y = 0f;

        if (Keyboard.current.wKey.isPressed) y = 1f;
        if (Keyboard.current.sKey.isPressed) y = -1f;
        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;

        movimiento = new Vector2(x, y);

        // Evitar que el movimiento diagonal sea más rápido
        movimiento = Vector2.ClampMagnitude(movimiento, 1f);

        // Comprobar si el jugador está en el suelo
        enSuelo = Physics.Raycast(
            transform.position,
            Vector3.down,
            distanciaSuelo
        );

        // Detectar la pulsación del salto
        if (Keyboard.current.spaceKey.wasPressedThisFrame && enSuelo)
        {
            quiereSaltar = true;
        }

        // Si cae respawnea
        if (transform.position.y < limiteCaida)
        {
            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 direccion = new Vector3(
            movimiento.x,
            0f,
            movimiento.y
        );

        // Movimiento del jugador
        rb.AddForce(direccion * fuerza);

        // Salto del jugador
        if (quiereSaltar)
        {
            rb.AddForce(
                Vector3.up * fuerzaSalto,
                ForceMode.Impulse
            );

            quiereSaltar = false;
        }
    }
}