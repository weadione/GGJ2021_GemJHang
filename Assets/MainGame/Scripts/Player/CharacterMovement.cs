using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed;
    public float tmpSpeed;
    public float dashSpeed = 100f;                  
    public float jumpForce = 700f;                  
    private Rigidbody2D rigid2D;                    

    private int jumpCount = 0;                      
    private bool isGrounded = false;                //true면 땅에 붙어있는거 / false면 땅에서 떨어져있는거

    public bool canMove=true;                       //true면 움직일 수 있는 상태 / false면 움직일 수 없는 상태

    public GameObject head;
    public GameObject arm;
    public GameObject leg;
    public GameObject upperBody;
    public GameObject lowerBody;


    int playerLayer, platformLayer, footLayer, maplePlatformLayer, bulletLayer;
    private Animator lowerBodyAnimator, upperBodyAnimator;
    private Animator armAnimator;


    private void Update()
    {
        //Debug.Log("스텟: " + PlayerState.Instance.jumpCount);
        //Debug.Log(jumpCount);
    }

    public void Move(float x)                       //기본 캐릭터 이동 함수, x가 +면 이동속도와 곱해져서 오른쪽으로 이동 / -면 왼쪽으로 이동
    {
        moveSpeed = GetComponent<PlayerState>().moveSpeed;
        if (canMove)
            rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()                              //기본 점프 함수, 스페이스 누르면 점프 가능
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < PlayerState.Instance.jumpCount)       // 점프 카운트가 2이상이면 점프 불가능(땅에 있을때 0임)
            {
                
                jumpCount++;
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(new Vector2(0, PlayerState.Instance.jumpForce));
                lowerBodyAnimator.SetTrigger("jump");
                
            }
            else if (Input.GetKeyUp(KeyCode.Space) && rigid2D.velocity.y > 0)   //스페이스 키가 떼어질 때 실행되어서 짧은 점프 실행하는거
            {
                rigid2D.velocity *= 0.5f;
            }



            if(!isGrounded && rigid2D.velocity.y > 0)                           //*메이플 맵* 땅에 안붙어있고, 위로 올라가는 상태일 때 footLayer와 platformLayer의 충돌을 없애는 것
            {
                Physics2D.IgnoreLayerCollision(footLayer, maplePlatformLayer, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(footLayer, maplePlatformLayer, false);
            }
        }
    }

    public void Hit(float x)                                                    //피격 시 x방향으로 밀려나고 위로도 조금 밀려남(x가 때린 방향)
    {
        x = x >= 0 ? 1 : -1;
        rigid2D.velocity = new Vector2(x * 15, 3);
    }

    public void Dash(float x)                                                   //대쉬 함수 코루틴으로 돌아감
    {
        if(canMove && PlayerState.Instance.dash)
            StartCoroutine(waitDash());
        
    }



    public void Direction()                                                     //
    {
        if (rigid2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            lowerBodyAnimator.SetBool("moving", true);
        }
        else if (rigid2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            lowerBodyAnimator.SetBool("moving", true);
        }
        else
        {
            lowerBodyAnimator.SetBool("moving", false);
        }

    }

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        isGrounded = true;
        lowerBodyAnimator = lowerBody.GetComponentInChildren<Animator>();
        moveSpeed = GetComponent<PlayerState>().moveSpeed;
        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        footLayer = LayerMask.NameToLayer("PlayerFoot");
        maplePlatformLayer = LayerMask.NameToLayer("MaplePlatform");
        bulletLayer = LayerMask.NameToLayer("Bullet");
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);           //Player레이어가 Platform 레이어와 충돌하지 않게 만드는 함수
        Physics2D.IgnoreLayerCollision(playerLayer, maplePlatformLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, maplePlatformLayer, false);
        Physics2D.IgnoreLayerCollision(playerLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(bulletLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, bulletLayer, true);
        Physics2D.IgnoreLayerCollision(14, 15, true);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.contacts[0].normal.y);
        // 바닥에 닿았음을 감지하는 처리
        //Debug.Log(collision.contacts[0].normal.y);
        for (int i = 0; i < collision.contacts.Length; i++)
            if (collision.contacts[i].normal.y > 0.7f && collision.contacts[i].collider.tag == "Map")
            {
                Debug.Log(collision.contacts.Length);
                isGrounded = true;
                jumpCount = 0;
            }

    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    for (int i = 0; i < collision.contacts.Length; i++)
    //        if (collision.contacts[i].normal.y > 0.7f && collision.contacts[i].collider.tag == "Map")
    //        {
    //            //Debug.Log(i + "번: " + collision.contacts[0].normal.y);
    //            isGrounded = true;
    //            jumpCount = 0;
    //        }
    //}


    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }

    private IEnumerator waitDash()
    {
        tmpSpeed = moveSpeed;
        moveSpeed = 70f;
        yield return new WaitForSeconds(0.1f);
        moveSpeed = tmpSpeed;
    }

 
}
