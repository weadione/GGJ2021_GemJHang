using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{
    public CharacterMovement enemyMove;
    public float lastAttTime;

    int playerLayer, enemyLayer, footLayer;

    public int[] item;

    protected override void OnEnable()
    {
        base.OnEnable();

        attDamage = 10f;
        health = 100f;
        attType = true;
        attSpeed = 1f;
        moveSpeed = 5f;
        dashSpeed = 30f;
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
        enemyMove = GetComponent<CharacterMovement>();
        StartCoroutine(UpdateMove());

        item = new int[3];

        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        footLayer = LayerMask.NameToLayer("PlayerFoot");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, enemyLayer, true);
    }
    private void Update()
    {
        enemyMove.Move(1);
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
