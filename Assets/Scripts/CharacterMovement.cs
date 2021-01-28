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
    private bool isGrounded = false;

    public bool canMove=true;

    public GameObject head;
    public GameObject arm;
    public GameObject leg;


    int playerLayer, platformLayer, footLayer;
    private Animator bodyAnimator;
    private Animator armAnimator; 

    public void Move(float x)
    {
        if (canMove)
            rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
            {
                jumpCount++;
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(new Vector2(0, jumpForce));
                bodyAnimator.SetTrigger("jump");
                armAnimator.SetTrigger("jump");
            }
            else if (Input.GetKeyUp(KeyCode.Space) && rigid2D.velocity.y > 0)
            {
                rigid2D.velocity *= 0.5f;
                bodyAnimator.SetTrigger("jump");
                armAnimator.SetTrigger("jump");
            }



            if(rigid2D.velocity.y <= 0)
            {
                Physics2D.IgnoreLayerCollision(footLayer, platformLayer, false);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(footLayer, platformLayer, true);
            }
        }
    }

    public void Hit(float x)
    {
        rigid2D.velocity = new Vector2(x * 3, 3);
    }
    public void Dash(float x)
    {
        if(canMove)
            StartCoroutine(waitDash());
        
    }

    public void Direction()
    {
        if (rigid2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            bodyAnimator.SetBool("moving", true);
            armAnimator.SetBool("moving", true);
        }
        else if (rigid2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
            bodyAnimator.SetBool("moving", true);
            armAnimator.SetBool("moving", true);
        }
        else
        {
            bodyAnimator.SetBool("moving", false);
            armAnimator.SetBool("moving", false);
        }

    }

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        bodyAnimator = GetComponent<Animator>();
        armAnimator = arm.GetComponent<Animator>();

        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        footLayer = LayerMask.NameToLayer("PlayerFoot");
        Physics2D.IgnoreLayerCollision(playerLayer, platformLayer, true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았음을 감지하는 처리
        if (collision.contacts[0].normal.y > 0.7f)
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
