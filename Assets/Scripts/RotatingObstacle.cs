using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float velociadad =100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, velociadad * Time.deltaTime, 0);
    }
}
