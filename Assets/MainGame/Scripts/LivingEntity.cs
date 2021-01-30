using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//살아있는 모든 개체의 
public class LivingEntity : MonoBehaviour
{
    public float health;
    public bool dead;
    public float attDamage;
    public bool attType;//true: 근거리, false :원거리
    public float attSpeed;
    public float moveSpeed;
    public float dashSpeed;

    public event Action onDeath;

    protected virtual void OnEnable()
    {
        // 사망하지 않은 상태로 시작
        dead = false;
    }
    public virtual void OnDamage(float damage)
    {
        // 데미지만큼 체력 감소
        health -= damage;

        // 체력이 0 이하 && 아직 죽지 않았다면 사망 처리 실행
        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(float newHealth)
    {
        if (dead)
        {
            // 이미 사망한 경우 체력을 회복할 수 없음
            return;
        }

        // 체력 추가
        health += newHealth;
    }

    public virtual void Die()
    {
        // onDeath 이벤트에 등록된 메서드가 있다면 실행
        if (onDeath != null)
        {
            onDeath();
        }

        // 사망 상태를 참으로 변경
        dead = true;
    }
}
