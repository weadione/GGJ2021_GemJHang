using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{
    public CharacterMovement enemyMove;
    public float lastAttTime;
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

                PlayerState playerState = other.GetComponent<PlayerState>();
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                playerState.HitDetect(enemyMove.moveSpeed);
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
                PlayerState playerState = other.GetComponent<PlayerState>();
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                playerState.HitDetect(enemyMove.moveSpeed);

            }
        }
    }

    private void Start()
    {
        lastAttTime = Time.time;
        enemyMove = GetComponent<CharacterMovement>();
        StartCoroutine(UpdateMove());
    }
    private void Update()
    {
        enemyMove.Move(1);
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
}
