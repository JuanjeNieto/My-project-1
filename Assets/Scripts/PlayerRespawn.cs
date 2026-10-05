using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform RespawnPoint;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        transform.position = RespawnPoint.position;
        rb.linearVelocity = Vector3.zero;
    }
}
