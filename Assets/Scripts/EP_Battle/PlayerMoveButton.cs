using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveButton : MonoBehaviour
{
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;


    [Header("Move")]
    Rigidbody2D rigid;
    public float moveSpeed;
    public float jumpPower;


    [Header("HP")]

    public int health;

    [Header("State")]
    public bool isDead;


    SpriteRenderer spriteRenderer;
    public Slider healthBar;
    public int bossAttackDamage;

    public AudioSource attacksound;
    private BattleBgmControl battleBgmControl;

    Animator anim;
    Vector3 moveVelocity = Vector3.zero;
    // Start is called before the first frame update

    public Boss boss;
    void Start()
    {
        battleBgmControl = GameObject.Find("EPGameBGMSystem").GetComponent<BattleBgmControl>();

        anim = gameObject.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim.SetBool("Jumping", true);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputJump && !anim.GetBool("Jumping"))
        { //무한 점프 막기
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("Jumping", true);
        }
        if (inputLeft)
        {
            anim.SetBool("Walking", true);
            spriteRenderer.flipX = true;
            moveVelocity = new Vector3(-0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;

        }
        else if (inputRight)
        {
            anim.SetBool("Walking", true);
            spriteRenderer.flipX = false;
            moveVelocity = new Vector3(0.10f, 0, 0);
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;

        }


        healthBar.value = health;
        if (health <= 0)
        {
            gameObject.layer = 0;
            anim.SetTrigger("Death");
            isDead = true;
        }
        if (health <= 30)
        {
            if (health != 0 && !isDead && !boss.isDead)
            {
                Debug.Log("bgm시작");
                Debug.Log(boss.isDead);
                Debug.Log(isDead);
                battleBgmControl.StartLowEnergyBgm();
            }

        }

    }


    private void FixedUpdate()
    {
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
                    inputJump = false;
                    //Debug.Log("워킹" + anim.GetBool("Walking").ToString());
                    //Debug.Log("점핑" + anim.GetBool("Jumping").ToString());

                }
            }
        }

    }

    public void onDamaged()
    {
        if (!(gameObject.layer == 8))
        {
            attacksound.Play();
            health -= bossAttackDamage;

        }
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
