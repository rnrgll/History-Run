using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;
    public bool inputAttack = false;




    [Header("Move")]
    Rigidbody2D rigid;
    public float maxSpeed; //최대 속력 제한 (가속을 무한으로 받지 않도록)
    //접근 지정자가 public 이기 때문에 inspector 창에서 접근 가능
    public float jumpPower;


    [Header("HP")]

    public int health;

    [Header("State")]
    public bool isDead;


    SpriteRenderer spriteRenderer;
    public Slider healthBar;
    public int bossAttackDamage;



    Animator anim; //애나메이터 가져오기





    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("Jumping", true);
        isDead = false;


    }


    private void Update()
    {
        //jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("Jumping"))
        { //무한 점프 막기
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("Jumping", true);
        }


        //moving
        if ((!inputRight && !inputLeft))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            anim.SetBool("Walking", false);

        }
        else if (inputLeft)
        {

            spriteRenderer.flipX = true;

        }
        else if (inputRight)
        {
            spriteRenderer.flipX = false;
        }


        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            //방향을 구할 때 normalized를 사용한다.
            //normalized는 Vector2니까 자료형 맞게 사용하자!

        }
        //Direction Sprite
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
                return;
            else
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.25)
            //매개변수 자료형에 따른 셋팅 함수 고르기
            //함수의 첫 매개변수는 만든 파라미터 이름
            // 두 번째 매개변수는 넣어줄 값. (셋팅할 값)
            anim.SetBool("Walking", false);
        else
            anim.SetBool("Walking", true);




        healthBar.value = health;
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            gameObject.layer = 0;
            isDead = true;
        }





    }
    private void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");
        //오브젝트가 어느 방향으로 이동 중인지 체크해야 함
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);


        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); //y축 속도는 rigid의 현재 y축 속도를 그대로 유지한다. (나중에 점프를 하기 때문)
        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * 10, new Color(0, 1, 0)); //에디터에 초록색 ray를 생성
            //Ray를 쏘아 ray에 충돌한 오브젝트를 받아오기
            //물리기반이기 때문에 Physics2D.Raycast 함수 사용
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 10, LayerMask.GetMask("Ground")); //rayHit에 오브젝트 정보가 저장됨

            //충돌한 오브젝트가 없으면 Physics2D.Raycast()가 null을 반환하기 때문에 이를 확인해 주어야 함
            if (rayHit.collider != null)
            {
                //바닥 감지
                if (rayHit.distance < 6f)
                {
                    anim.SetBool("Jumping", false);
                    //Debug.Log("워킹" + anim.GetBool("Walking").ToString());
                    //Debug.Log("점핑" + anim.GetBool("Jumping").ToString());

                }
            }
        }

    }
    //충돌
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            onDamaged();

        }
    }

    public void onDamaged()
    {
        if (!(gameObject.layer == 8))
            health -= bossAttackDamage;
        //Change Layer (Immortal Active)
        gameObject.layer = 8;
        // View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 0.4f); //투명도까지 (알파값)
        //Reaction Force
        Invoke("OffDamaged", 2f);

    }

    public void OffDamaged()
    {
        gameObject.layer = 0;
        spriteRenderer.color = new Color(1, 1, 1, 1);

    }



}
