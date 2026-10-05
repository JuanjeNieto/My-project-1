using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        PlayerRespawn player = other.GetComponent<PlayerRespawn>();
        if(player != null){

            player.Respawn();
            
        }

    }
}
