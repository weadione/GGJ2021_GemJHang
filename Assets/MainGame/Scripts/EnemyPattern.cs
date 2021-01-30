using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPattern : MonoBehaviour
{
    public int actNum = 0;
    public EnemyMovement movement;
    private float lastMoveTime;
    private float lastTimeRest;
    private bool borderMove;
    private bool berserkerMode;

    public GameObject left;
    public GameObject right;
    public BoxCollider2D Tracer;

    private int selecrPattern;


    private void Start()
    {
        movement = GetComponent<EnemyMovement>();
        lastMoveTime = 0;
        lastTimeRest = 0;
        borderMove = true;
        berserkerMode = false;
        //selecrPattern = 0;
    }

    private void Update()
    {
        if (selecrPattern == 1)
            pattern1();
        else if (selecrPattern == 2)
            pattern2();
        else if (selecrPattern == 3)
            pattern3();
        else
            Debug.Log("else");
    }

    public void SelectPattern(int num)
    {
        selecrPattern = num;
        Debug.Log(num);
    }

    public void pattern1()
    {
        float delay = Random.Range(2.0f, 3.0f);
        if (transform.position.x <= left.transform.position.x && borderMove)
        {
            borderMove = false;
            if (Time.time >= lastTimeRest + 1.0f)
            {
                movement.Move(0.5f);
            }
            lastTimeRest = Time.time;

            StartCoroutine(WaitBorder());
        }
        else if (transform.position.x >= right.transform.position.x && borderMove)
        {
            borderMove = false;
            if (Time.time >= lastTimeRest + 1.0f)
            {
                movement.Move(-0.5f);
            }
            lastTimeRest = Time.time;

            StartCoroutine(WaitBorder());
        }


        if (borderMove)
        {
            if (Time.time >= lastMoveTime + delay)
            {
                int paramter = Random.Range(1, 7);

                Debug.Log(paramter);
                if (paramter <= 2)
                {
                    movement.Move(-0.5f);
                }
                else if (paramter > 2 && paramter<=4)
                {
                    movement.Move(0.5f);
                }
                else
                {
                    movement.Move(0);
                }
                lastMoveTime = Time.time;
            }
        }
    }

    public void pattern2()
    {

        float delay = Random.Range(2.0f, 3.0f);
        if (transform.position.x <= left.transform.position.x && borderMove)
        {
            borderMove = false;
            if (Time.time >= lastTimeRest + 1.0f)
            {
                movement.Move(0.5f);
            }

            lastTimeRest = Time.time;
            StartCoroutine(WaitBorder());
        }
        else if (transform.position.x >= right.transform.position.x &&borderMove)
        {

            borderMove = false;
            if (Time.time >= lastTimeRest + 1.0f)
            {
                movement.Move(-0.5f);
            }
            lastTimeRest = Time.time;

            StartCoroutine(WaitBorder());
        }

        if(borderMove)
        {
            if (Tracer.IsTouching(PlayerState.Instance.GetComponent<CompositeCollider2D>()))
            {
                if (transform.position.x > PlayerState.Instance.transform.position.x)
                {
                       movement.Move(-0.5f);
                }
                else if (transform.position.x < PlayerState.Instance.transform.position.x)
                {
                       movement.Move(0.5f);
                }
                else
                {
                    movement.Move(0f);
                }
            }
            else if (Time.time >= lastMoveTime + delay)
            {
                int paramter = Random.Range(1, 8);

                Debug.Log(paramter);
                if (paramter <= 2)
                {
                    movement.Move(-0.5f);
                }
                else if (paramter > 2 && paramter <= 4)
                {
                    movement.Move(0.5f);
                }
                else
                {
                    movement.Move(0);
                }
                lastMoveTime = Time.time;
            }
        }
    }

    public void pattern3()
    {
        float delay = Random.Range(2.0f, 3.0f);
        if (Tracer.IsTouching(PlayerState.Instance.GetComponent<CompositeCollider2D>()))
        {
            berserkerMode = true;
        }


        if (!berserkerMode)
        {
            if (transform.position.x <= left.transform.position.x && borderMove)
            {
                borderMove = false;
                if (Time.time >= lastTimeRest + 1.0f)
                {
                    movement.Move(0.5f);
                }

                lastTimeRest = Time.time;
                StartCoroutine(WaitBorder());
            }
            else if (transform.position.x >= right.transform.position.x && borderMove)
            {

                borderMove = false;
                if (Time.time >= lastTimeRest + 1.0f)
                {
                    movement.Move(-0.5f);
                }
                lastTimeRest = Time.time;

                StartCoroutine(WaitBorder());
            }

            if (borderMove)
            {
                if (Time.time >= lastMoveTime + delay)
                {
                    int paramter = Random.Range(1, 8);

                    Debug.Log(paramter);
                    if (paramter <= 2)
                    {
                        movement.Move(-0.5f);
                    }
                    else if (paramter > 2 && paramter <= 4)
                    {
                        movement.Move(0.5f);
                    }
                    else
                    {
                        movement.Move(0);
                    }
                    lastMoveTime = Time.time;
                }
            }

        }
        else
        {
            if (transform.position.x > PlayerState.Instance.transform.position.x+0.5f)
            {
                movement.Move(-0.5f);
            }
            else if (transform.position.x < PlayerState.Instance.transform.position.x-0.5f)
            {
                movement.Move(0.5f);
            }
            else
                movement.Move(0f);
        }

        
    }

    public void WallJump()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError("닿음");
    }

    private IEnumerator WaitBorder()
    {
        yield return new WaitForSeconds(1.0f);
        borderMove = true;
    }


}
