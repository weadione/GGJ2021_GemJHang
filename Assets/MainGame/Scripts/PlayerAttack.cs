using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float tmpTime;
    public bool canAttack =true;

    public Animator attackAnimator;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (!PlayerState.Instance.dead && canAttack && Time.time >= PlayerState.Instance.lastAttTime + PlayerState.Instance.attSpeed)
            {
                LivingEntity target = other.GetComponent<LivingEntity>();
                EnemyState enemyState = other.GetComponent<EnemyState>();
                target.OnDamage(PlayerState.Instance.attDamage);
                PlayerState.Instance.lastAttTime = Time.time;
                canAttack = false;
                enemyState.HitDetect(0);

                attackAnimator.SetTrigger("attack");

            }
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && !canAttack && Time.time >= PlayerState.Instance.lastAttTime + PlayerState.Instance.attSpeed)
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
