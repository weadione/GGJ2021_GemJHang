using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;                    
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


    int playerLayer, platformLayer, footLayer;
    private Animator lowerBodyAnimator, upperBodyAnimator;
    private Animator armAnimator; 

    public void Move(float x)                       //기본 캐릭터 이동 함수, x가 +면 이동속도와 곱해져서 오른쪽으로 이동 / -면 왼쪽으로 이동
    {
        if (canMove)
            rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()                              //기본 점프 함수, 스페이스 누르면 점프 가능
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)       // 점프 카운트가 2이상이면 점프 불가능(땅에 있을때 0임)
            {
                jumpCount++;
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(new Vector2(0, jumpForce));
                lowerBodyAnimator.SetTrigger("jump");
            }
            else if (Input.GetKeyUp(KeyCode.Space) && rigid2D.velocity.y > 0)   //스페이스 키가 떼어질 때 실행되어서 짧은 점프 실행하는거
            {
                rigid2D.velocity *= 0.5f;
            }



            if(!isGrounded && rigid2D.velocity.y > 0)                           //*메이플 맵* 땅에 안붙어있고, 위로 올라가는 상태일 때 footLayer와 platformLayer의 충돌을 없애는 것
            {
                Physics2D.IgnoreLayerCollision(footLayer, platformLayer, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(footLayer, platformLayer, false);
            }
        }
    }

    public void Hit(float x)                                                    //피격 시 x방향으로 밀려나고 위로도 조금 밀려남(x가 때린 방향)
    {
        rigid2D.velocity = new Vector2(x * 3, 3);
    }

    public void Dash(float x)                                                   //대쉬 함수 코루틴으로 돌아감
    {
        if(canMove)
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
        lowerBodyAnimator = lowerBody.GetComponentInChildren<Animator>();

        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        footLayer = LayerMask.NameToLayer("PlayerFoot");
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);                       //Player레이어가 Platform 레이어와 충돌하지 않게 만드는 함수
    }

    private void OnCollisionEnter2D(Collision2D collision)                                      
    {
        //Debug.Log(collision.contacts[0].normal.y);
        // 바닥에 닿았음을 감지하는 처리
        if (collision.contacts[0].normal.y > 0f)
        {
            isGrounded = true;
            jumpCount = 0;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }

    private IEnumerator waitDash()
    {
        moveSpeed = 30f;
        //Debug.LogError(moveSpeed);
        yield return new WaitForSeconds(0.1f);
        moveSpeed = 5f;
        //Debug.LogError(moveSpeed);
    }
}
