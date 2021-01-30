using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float tmpTime;
    public bool canAttack =true;

    public bool canAttackFar = true;

    public GameObject bullet;

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
            if (PlayerState.Instance.attType)
            {
                canAttack = true;
                StartCoroutine(WaitAttack());
            }
            else
            {
                canAttackFar = true;
                //원거리
                GameObject tmpBullet = Instantiate(bullet, transform.position, transform.rotation);
                tmpBullet.GetComponent<Rigidbody2D>().velocity = PlayerState.Instance.transform.localScale.x >= 0 ? new Vector2(-10, 0) : new Vector2(10, 0);
                tmpBullet.transform.localScale = PlayerState.Instance.transform.localScale.x >= 0 ? tmpBullet.transform.localScale : new Vector3(-tmpBullet.transform.localScale.x, tmpBullet.transform.localScale.y, tmpBullet.transform.localScale.z);
                PlayerState.Instance.lastAttTime = Time.time;
            }

        }
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.1f );
        canAttack = false;
    }
}
