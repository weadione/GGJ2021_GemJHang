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

    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
            rigid2D.velocity = Vector2.zero;
            rigid2D.AddForce(new Vector2(0, jumpForce));
        }
        else if (Input.GetKeyUp(KeyCode.Space) && rigid2D.velocity.y > 0)
        {
            rigid2D.velocity *= 0.5f;
        }
    }

    public void Dash(float x)
    {
        
        
        
        StartCoroutine(waitDash());
        
    }

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
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
        Debug.LogError(moveSpeed);
        yield return new WaitForSeconds(0.1f);
        moveSpeed = 5f;
        Debug.LogError(moveSpeed);
    }
}
