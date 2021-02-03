﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float tmpTime;
    public bool canAttack =true;

    public bool canAttackFar = true;

    public GameObject[] bullet;

    public Animator attackAnimator;
    public Animator[] armAttackAnimator;

    public AudioSource playerAttackSound;
    public AudioClip nearAtt;
    public AudioClip farAtt;


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

                attackAnimator.SetTrigger("attackTrigger");
                armAttackAnimator[PlayerState.Instance.partsNum[1]-1].SetTrigger("attackTrigger");
                playerAttackSound.PlayOneShot(nearAtt);
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
                int bulletNum = 0;
                if(PlayerState.Instance.partsNum[1] == 2)
                {
                    bulletNum = 0;
                }
                else if(PlayerState.Instance.partsNum[1]== 3)
                {
                    bulletNum = 1;
                }
                else if (PlayerState.Instance.partsNum[1] == 4)
                {
                    bulletNum = Random.Range(2, 5);
                }
                else if (PlayerState.Instance.partsNum[1] == 5)
                {
                    bulletNum = Random.Range(2, 5);
                }
                else if (PlayerState.Instance.partsNum[1] == 6)
                {
                    bulletNum = Random.Range(5, 7);
                }




                GameObject tmpBullet = Instantiate(bullet[bulletNum], new Vector2(transform.position.x,transform.position.y+0.5f), transform.rotation);
                tmpBullet.GetComponent<Rigidbody2D>().velocity = PlayerState.Instance.transform.localScale.x >= 0 ? new Vector2(-10, 0) : new Vector2(10, 0);
                tmpBullet.transform.localScale = PlayerState.Instance.transform.localScale.x >= 0 ? tmpBullet.transform.localScale : new Vector3(-tmpBullet.transform.localScale.x, tmpBullet.transform.localScale.y, tmpBullet.transform.localScale.z);
                PlayerState.Instance.lastAttTime = Time.time;

                attackAnimator.SetTrigger("attackTrigger");
                armAttackAnimator[PlayerState.Instance.partsNum[1]-1].SetTrigger("attackTrigger");
                playerAttackSound.PlayOneShot(farAtt);
            }

        }
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.1f );
        canAttack = false;
    }
}
