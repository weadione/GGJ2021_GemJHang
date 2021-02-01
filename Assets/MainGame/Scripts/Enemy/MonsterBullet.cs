using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LivingEntity target = collision.GetComponent<LivingEntity>();
            target.OnDamage(damage);
            PlayerState.Instance.HitDetect(GetComponent<Rigidbody2D>().velocity.x);

        }



        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
