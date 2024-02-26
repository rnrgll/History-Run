using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{

    public Boss boss;
    public PlayerMoveButton player;
    public AudioSource theifAttackSound;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && boss.isDead == false)
        {
            Debug.Log("충돌");
            Debug.Log(other.name);
            if (other.gameObject.layer == 0)
            {
                theifAttackSound.Play();
                player.onDamaged();



            }
            else if (other.gameObject.layer == 8)
            {
                Debug.Log("비활성 상태");
            }

        }
    }
}
