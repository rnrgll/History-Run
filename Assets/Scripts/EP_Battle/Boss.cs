using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;

    public Slider healthBar;
    private Animator anim;
    public bool isDead;

    public PlayerMoveButton player;
    public AudioSource deathSound;
    private bool isdeathSoundPlay = false;



    float time;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 40)
        {
            anim.SetTrigger("stageTwo");
            damage = 20;
        }

        if (health <= 0)
        {

            if (!isdeathSoundPlay)
            {
                deathSound.Play();
                isdeathSoundPlay = true;
            }

            anim.SetTrigger("death");
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;


        if (player.isDead)
        {

            anim.enabled = false;
        }
    }

    /*
        private void OnTriggerEnter2D(Collider2D other)
        {
            // deal the player damage ! 
            if (other.CompareTag("Player") && isDead == false) {
                Debug.Log("충돌");
                if(other.gameObject.layer == 0){
                    if (timeBtwDamage <= 0) {
                        other.GetComponent<PlayerMoveButton>().health -= damage;

                    }
                    //other.gameObject.layer = 8;
                    player.onDamaged();


                }
                else if(other.gameObject.layer == 8){

                }

            } 
        }*/

}
