using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int health;
    public int speed;


    //color

    private Animator anim;
    private Rigidbody2D rb;
    public Slider healthBar;

    SpriteRenderer spriteRendererHead;
    SpriteRenderer spriteRendererLeftLeg;
    SpriteRenderer spriteRendererRightLeg;
    SpriteRenderer spriteRendererWeapon;

    public bool isDead;


    //jump
    bool jumping = false;
    public int jumpPower;
    public GameObject Weapon;
    public Transform target;


    //button
    public int move = 0;
    public bool jumpClick = false;

    Vector2 moveInput;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRendererHead = transform.Find("PlayerHead").GetComponent<SpriteRenderer>();
        spriteRendererLeftLeg = transform.Find("Leg Left").GetComponent<SpriteRenderer>();
        spriteRendererRightLeg = transform.Find("Leg Right").GetComponent<SpriteRenderer>();
        //Weapon = transform.Find("Weapon").game;
        spriteRendererWeapon = Weapon.GetComponent<SpriteRenderer>();
        target = Weapon.transform.GetChild(0).GetComponent<Transform>();

    }

    private void Update()
    {
        PlayerMove();
        /*
        if(Input.GetKey(KeyCode.RightArrow)||move==-1)
            moveInput = new Vector2(-1, 0);
        else if (move==1)
            moveInput = new Vector2(1,0);
        else
            moveInput = new Vector2(0,0);
    */

        //moveVelocity = new Vector2 (moveInput.x * speed, 0);

        //run
        if (moveInput != Vector2.zero)
        {
            if (!jumping)
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);
            if (moveInput.x == 0)
            {
                return;
            }
            else
            {
                spriteRendererHead.flipX = moveInput.x == -1;
                spriteRendererLeftLeg.flipX = moveInput.x == -1;
                spriteRendererRightLeg.flipX = moveInput.x == -1;
                spriteRendererWeapon.flipY = moveInput.x == -1;
                if (moveInput.x == -1)
                {
                    //target = Weapon.transform.GetChild(0).GetComponent<Transform>();
                    target.position = new Vector3(Weapon.transform.position.x - 4, target.position.y, target.position.z);
                }
                else
                {
                    target.position = new Vector3(Weapon.transform.position.x + 4, target.position.y, target.position.z);
                }
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        //healthBar updates
        healthBar.value = health;

        if (health <= 0)
        {
            anim.SetTrigger("Death");
        }

        Jump();

    }

    private void FixedUpdate()
    {
        //rb.MovePosition(new Vector2(rb.position.x + moveVelocity.x * Time.fixedDeltaTime, rb.position.y));


        //rayCast
        if (rb.velocity.y < 0)
        {
            Debug.DrawRay(rb.position, Vector3.down * 4, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 4, LayerMask.GetMask("Ground"));
            if (rayHit.collider != null)
            {
                Debug.Log("not null");
                if (rayHit.distance < 3f)
                {
                    Debug.Log("바닥감지");
                    jumping = false;
                    jumpClick = false;
                }
            }

        }


    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow) || move == 1)
        {
            //rb.AddForce(Vector2.right,ForceMode2D.Force);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            moveInput = new Vector2(1, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || move == -1)
        {
            //rb.AddForce(Vector2.left,ForceMode2D.Force);
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            moveInput = new Vector2(-1, 0);
        }
        else
        {
            moveInput = new Vector2(0, 0);
        }



    }


    void Jump()
    {

        if ((Input.GetKey(KeyCode.UpArrow) || jumpClick) && !jumping)
        {
            //rb.position = new Vector2(rb.position.x, rb.position.y+jumpPower);
            //rb.MovePosition(rb.position * Time.fixedDeltaTime);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumping = true;
        }
    }


    public void onDamage()
    {
        gameObject.layer = 8;
        spriteRendererHead.color = new Color(1, 1, 1, 0.4f);
        spriteRendererWeapon.color = new Color(1, 1, 1, 0.4f);

        Invoke("offDamage", 1);
    }

    public void offDamage()
    {
        gameObject.layer = 0;
        spriteRendererHead.color = new Color(1, 1, 1, 1);
        spriteRendererWeapon.color = new Color(1, 1, 1, 1);
    }



    public void leftpush()
    {
        move = -1;
    }
    public void rightpush()
    {
        move = 1;
    }
    public void stop()
    {
        move = 0;
    }
    public void jumppush()
    {
        if (!jumpClick)
            jumpClick = true;
    }

}
