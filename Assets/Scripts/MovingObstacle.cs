using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private  Transform puntoA;
    [SerializeField] private  Transform puntoB;
    [SerializeField] private float velocidad = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time * velocidad, 1f);
        transform.position = Vector3.Lerp(puntoA.position, puntoB.position, t);
    }
}
