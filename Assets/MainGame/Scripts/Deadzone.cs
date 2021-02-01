using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    GameObject respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerState.Instance.transform.position = respawnPoint.transform.position;
            PlayerState.Instance.OnDamage(10);
        }
        else if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyState>().OnDamage(1000);
        }
    }
}
