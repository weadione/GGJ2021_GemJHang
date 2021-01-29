using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerState state;
    public float tmpTime;
    public bool canAttack =true;

    public Animator attackAnimator;

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
                attackAnimator.SetTrigger("attack");

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
