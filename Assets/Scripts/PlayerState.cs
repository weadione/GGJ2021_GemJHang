using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : LivingEntity
{

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

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }
}
