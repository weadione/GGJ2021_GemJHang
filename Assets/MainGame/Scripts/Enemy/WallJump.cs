using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public EnemyMovement movement;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Map")
        {
            movement.Jump();
        }
    }
}
