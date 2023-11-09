using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;
    public GameObject explosion;
    public GameObject explosionTwo;

    public bool filp=false;
    GameObject Player;
    
    private void Start() {
        Player = GameObject.Find("Player");
    }


    private void Update()
    {   
        if(filp){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the boss some damage + spawn particle effects + screen shake
        if (other.CompareTag("Boss")) {
  
            other.GetComponentInParent<Boss>().health -= damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Instantiate(explosionTwo, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

/*    public bool isFilp(){
        if(Player.GetComponent<SpriteRenderer>().flipX)
            return true;
        else return false;
    }*/
}
