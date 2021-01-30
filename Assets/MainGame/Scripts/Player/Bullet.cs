using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effect;

    private void Start()
    {
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            LivingEntity target = collision.GetComponent<LivingEntity>();
            EnemyState enemyState = collision.GetComponent<EnemyState>();
            target.OnDamage(PlayerState.Instance.attDamage);
            enemyState.HitDetect(0);
            effect.SetActive(true);
        }

        if(collision.tag != "Dead")
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
