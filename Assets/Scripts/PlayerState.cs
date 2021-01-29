using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : LivingEntity
{
    public CharacterMovement movement;

    private float lastAttTime;

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
    private void Start()
    {
        movement = GetComponent<CharacterMovement>();
        lastAttTime = 0f;

    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
            
        
    }

    private void Update()
    {
        //Debug.Log(health);
    }
    
    public void HitDetect(float x)
    {
        StartCoroutine(WaitHit());
        movement.Hit(x);
    }

    private IEnumerator WaitHit()
    {
        if (dead)
            yield break;
        movement.canMove = false;
        yield return new WaitForSeconds(0.2f);
        movement.canMove = true;
    }

    public override void Die()
    {

        base.Die();
        dead = true;
        movement.canMove = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (!dead && Time.time >= lastAttTime + attSpeed)
            {

                LivingEntity target = other.GetComponent<LivingEntity>();

                PlayerState playerState = other.GetComponent<PlayerState>();
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                //playerState.HitDetect(enemyMove.moveSpeed);
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
                //playerState.HitDetect(enemyMove.moveSpeed);

            }
        }
    }

}
