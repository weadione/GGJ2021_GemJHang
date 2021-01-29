using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerState state;
    public float tmpTime;
    public bool canAttack =true;

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.tag == "Enemy")
    //    {
    //        if (!state.dead && canAttack)
    //        {

    //            LivingEntity target = other.GetComponent<LivingEntity>();

    //            PlayerState playerState = other.GetComponent<PlayerState>();
    //            target.OnDamage(state.attDamage);
                
    //            //playerState.HitDetect(enemyMove.moveSpeed);
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (!state.dead && canAttack && Time.time >= state.lastAttTime + state.attSpeed)
            {
                LivingEntity target = other.GetComponent<LivingEntity>();
                EnemyState enemyState = other.GetComponent<EnemyState>();
                target.OnDamage(state.attDamage);
                state.lastAttTime = Time.time;
                canAttack = false;
                enemyState.HitDetect(0);

            }
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && !canAttack)
        {
            
            canAttack = true;
            StartCoroutine(WaitAttack());

        }
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.1f );
        canAttack = false;
    }
}
