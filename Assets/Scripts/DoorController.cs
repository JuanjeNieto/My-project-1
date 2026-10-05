using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float altura = 4f;
    [SerializeField] private float velocidad = 2f;

    private Vector3 posicionCerrada;
    private Vector3 posicionAbierta;
    private bool abierta = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionCerrada = transform.position;
        posicionAbierta = posicionCerrada + Vector3.up * altura;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destino = abierta ? posicionAbierta : posicionCerrada;
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
    }
    public void Abrir()
    {
        abierta = true;
    }

    public void Cerrar()
    {
        abierta = false;
    }

    public bool Abierta => abierta;
}
