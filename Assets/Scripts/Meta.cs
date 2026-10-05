using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject textoFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textoFinal.SetActive(true);
        }
    }
}