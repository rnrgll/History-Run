using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{

    private Transform playerPos;
    public float speed;
    Vector2 target;
    Vector2 endpoint;
    public Boss boss;
    public PlayerMoveButton player;
    private void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void Update() {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector2(playerPos.position.x, transform.position.y);
        endpoint = new Vector2(transform.position.x, 0);

    }


    private void FixedUpdate() {
        if(!boss.isDead&&!player.isDead){
            if(target.x > transform.position.x)
                boss.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            else
                boss.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            
        }
        if(boss.isDead)
            transform.position = Vector2.MoveTowards(transform.position, endpoint, speed * Time.deltaTime);
    }
    
}
