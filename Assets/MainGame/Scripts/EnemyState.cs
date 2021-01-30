using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{
    public EnemyMovement enemyMove;
    public float lastAttTime;

    int playerLayer, enemyLayer, footLayer, enemyFootLayer, detecterLayer;

    public int[] item;  //드랍할 파츠

    float tmpDamage, tmpHealth, tmpattSpeed, tmpmoveSpeed;
    //bool tmp

    //protected override void OnEnable()
    //{
    //    base.OnEnable();

    //    attDamage = 10f;
    //    health = 100f;
    //    attType = true;
    //    attSpeed = 1f;
    //    moveSpeed = 5f;
    //    dashSpeed = 30f;
    //    Debug.LogError(attDamage);

    //}

    public void changeState(float damage, float health,bool attType,float attSpeed, float moveSpeed)
    {
        this.attDamage = damage;
        this.health = health;
        this.attType = attType;
        this.attSpeed = attSpeed;
        this.moveSpeed = moveSpeed;
        Debug.LogError(this.attDamage);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (!dead &&Time.time>=lastAttTime+attSpeed)
            {

                LivingEntity target = other.GetComponent<LivingEntity>();

               
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                PlayerState.Instance.HitDetect(enemyMove.moveSpeed);
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (!dead && Time.time >= lastAttTime + attSpeed)
            {
                LivingEntity target = other.GetComponent<LivingEntity>();
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                PlayerState.Instance.HitDetect(enemyMove.moveSpeed);

            }
        }
    }


    public void HitDetect(float x)
    {
        StartCoroutine(WaitHit());
        enemyMove.Hit(x);
    }

    private IEnumerator WaitHit()
    {
        if (dead)
            yield break;
        enemyMove.canMove = false;
        yield return new WaitForSeconds(0.2f);
        enemyMove.canMove = true;
    }


    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        

    }

    private void Start()
    {
        lastAttTime = Time.time;
        enemyMove = GetComponent<EnemyMovement>();
        //StartCoroutine(UpdateMove());

        item = new int[3];

        enemyFootLayer = LayerMask.NameToLayer("EnemyFoot");
        detecterLayer = LayerMask.NameToLayer("Detecter");
        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        footLayer = LayerMask.NameToLayer("PlayerFoot");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyFootLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, enemyFootLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, enemyLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, detecterLayer, true);
        Physics2D.IgnoreLayerCollision(playerLayer, detecterLayer, true);
        Physics2D.IgnoreLayerCollision(enemyFootLayer, enemyFootLayer, true);

    }
    private void Update()
    {
        enemyMove.Direction();
        //enemyMove.Move(1);
        //Debug.Log("벌레:"+ health);
    }

    private IEnumerator UpdateMove()
    {
        while(true)
        {
            enemyMove.moveSpeed = 5f;
            yield return new WaitForSeconds(1.0f);
            enemyMove.moveSpeed = -5f;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public override void Die()
    {

        base.Die();
        dead = true;
        enemyMove.canMove = false;
        tag = "Dead";
       
    }
}
