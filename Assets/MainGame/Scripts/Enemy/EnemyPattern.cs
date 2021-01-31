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
    public Vector2 teleportPos;
    public GameObject monsterBullet;

    private int selecrPattern;
    private int keydown = 1;

    private float lastAttTime;
    private float nextPattern;

    private Vector2[] bulletDirection;


    private void Start()
    {
        movement = GetComponent<EnemyMovement>();
        lastMoveTime = 0;
        lastTimeRest = 0;
        borderMove = true;
        berserkerMode = false;
        lastAttTime = 0;
        nextPattern = 0;


        bulletDirection = new Vector2[11];
        bulletDirection[0] = new Vector2(-10, -2);
        bulletDirection[1] = new Vector2(-8, -6);
        bulletDirection[2] = new Vector2(-6, -8);
        bulletDirection[3] = new Vector2(-4, -9.1f);
        bulletDirection[4] = new Vector2(-2, -9.7f);
        bulletDirection[5] = new Vector2(0, -10);
        bulletDirection[6] = new Vector2(8, -6);
        bulletDirection[7] = new Vector2(6, -8);
        bulletDirection[8] = new Vector2(4, -9.1f);
        bulletDirection[9] = new Vector2(2, -9.7f);
        bulletDirection[10] = new Vector2(10, -2);
        bulletDirection[11] = new Vector2(9, -4.3f);
        bulletDirection[11] = new Vector2(-9, -4.3f);


    }

    private void Update()
    {
        if (selecrPattern == 1)
            pattern1();
        else if (selecrPattern == 2)
            pattern2();
        else if (selecrPattern == 3)
            pattern3();
        else if (selecrPattern == 4)
            MiddleBoss();


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

                //Debug.Log(paramter);
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
    private IEnumerator WaitBorder()
    {
        yield return new WaitForSeconds(1.0f);
        borderMove = true;
    }


    public void MiddleBoss()
    {
        float delay = Random.Range(2.0f, 3.0f);
        if (Tracer.IsTouching(PlayerState.Instance.GetComponent<CompositeCollider2D>()))
        {
            berserkerMode = true;
        }

        if (Time.time >= nextPattern + 5.0f && keydown == 1)
        {
            keydown = 2;
            nextPattern = Time.time;
        }
        else if (Time.time >= nextPattern + 5.0f && keydown == 2)
        {
            keydown = 1;
            nextPattern = Time.time;
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
            keydown = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            keydown = 2;


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
            if(keydown==1)
            {
                MiddleBossPattern1();
            }
            else if(keydown==2)
            {
                MiddleBossPattern2();
            }
        }
    }


    public void MiddleBossPattern1()
    {
        if (transform.position.x > PlayerState.Instance.transform.position.x + 0.5f)
        {
            movement.Move(-0.5f);
        }
        else if (transform.position.x < PlayerState.Instance.transform.position.x - 0.5f)
        {
            movement.Move(0.5f);
        }
        else
            movement.Move(0f);
    }

    public void MiddleBossPattern2()
    {
        transform.position = new Vector2(transform.position.x, teleportPos.y);

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

                //Debug.Log(paramter);
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



        if (Time.time >= lastAttTime + 1.0f)
        {
            for (int j = 0; j <= 7; j++)
            {
                int i = Random.Range(0, 11);
                Debug.Log(bulletDirection[i]);
                GameObject tmpBullet = Instantiate(monsterBullet, transform.position, transform.rotation);
                tmpBullet.GetComponent<Rigidbody2D>().velocity = bulletDirection[i] * 0.6f;
                tmpBullet.GetComponent<MonsterBullet>().damage = GetComponent<EnemyState>().attDamage;
                
            }
            
           lastAttTime = Time.time;
            //attackAnimator.SetTrigger("attackTrigger");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError("닿음");
    }



}
