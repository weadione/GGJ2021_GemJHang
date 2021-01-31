﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed = 30f;
    public float jumpForce = 400f;
    private Rigidbody2D rigid2D;

    //private int jumpCount = 0;
    private bool isGrounded = false;                //true면 땅에 붙어있는거 / false면 땅에서 떨어져있는거

    public bool canMove = true;                       //true면 움직일 수 있는 상태 / false면 움직일 수 없는 상태

    public Vector3 enemySclae;

    int playerLayer, platformLayer, footLayer, maplePlatformLayer;

    EnemyState enemyState;

    

    public void Move(float x)                       //기본 캐릭터 이동 함수, x가 +면 이동속도와 곱해져서 오른쪽으로 이동 / -면 왼쪽으로 이동
    {
        if (canMove)
            rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()                              //기본 점프 함수, 스페이스 누르면 점프 가능
    {
        if (canMove)
        {
            if (true)       
            {
                rigid2D.velocity = Vector2.zero;
                rigid2D.AddForce(new Vector2(0, PlayerState.Instance.jumpForce));
            }




            if (!isGrounded && rigid2D.velocity.y > 0)                           //*메이플 맵* 땅에 안붙어있고, 위로 올라가는 상태일 때 footLayer와 platformLayer의 충돌을 없애는 것
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
        rigid2D.velocity = new Vector2(x * 3, 3);
    }

    public void Dash(float x)                                                   //대쉬 함수 코루틴으로 돌아감
    {
        if (canMove)
            StartCoroutine(waitDash());
    }

    private IEnumerator waitDash()
    {
        moveSpeed = 30f;
        yield return new WaitForSeconds(0.1f);
        moveSpeed = 5f;
    }

    public void Direction()                                                     //
    {
        if (rigid2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(enemySclae.x, enemySclae.y, enemySclae.z);
        }
        else if (rigid2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(-enemySclae.x, enemySclae.y, enemySclae.z);
        }

    }

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        enemyState = GetComponent<EnemyState>();
        moveSpeed = enemyState.moveSpeed;
        isGrounded = true;
        enemySclae = transform.localScale;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contacts.Length; i++)
            if (collision.contacts[i].normal.y > 0.7f && collision.contacts[i].collider.tag == "Map")
            {

                isGrounded = true;
            }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }


}
