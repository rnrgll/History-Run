using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    public Boss boss;
    public PlayerMoveButton player;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && boss.isDead == false) {
            Debug.Log("충돌");
            if(other.gameObject.layer == 0){
                
                player.onDamaged();
            
                
            }
            else if(other.gameObject.layer == 8){
                
            }

        } 
    }
}
