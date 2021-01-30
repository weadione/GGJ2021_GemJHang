using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : LivingEntity
{
    public CharacterMovement movement;

    public float lastAttTime;

    public PartsManager partsManager;
    public int[] partsNum;

    public float defaultDamage;
    public float defaultHealth;
    public bool defaultAttType;
    public float defaultAttSpeed;
    public float defaultMoveSpeed;
    public float defaultDashSpeed;
    public float defaultAttRange;

    public float attRange;

    public float maxHealth;

    public int jumpCount;
    public bool dash;
    public float jumpForce;


    private static PlayerState instance;
    public static PlayerState Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                instance = FindObjectOfType<PlayerState>();
            }

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        attDamage = 10f;
        health = 100f;
        attType = false;
        attSpeed = 1f;
        moveSpeed = 5f;
        dashSpeed = 30f;
        attRange = 3f;
        maxHealth = 100f;

        jumpCount = 1;
        dash = false;
        jumpForce = 400;

        defaultDamage = 10f;
        defaultHealth = 100f;
        defaultAttType = true;
        defaultAttSpeed = 1f;
        defaultMoveSpeed = 5f;
        defaultDashSpeed = 30f;

    }


    private void Start()
    {
        partsNum = new int[3];
        partsManager = GetComponent<PartsManager>();
        movement = GetComponent<CharacterMovement>();
        lastAttTime = 0f;
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
            
        
    }

    private void Update()
    {
        Debug.Log(health);
    }
    
    public void HitDetect(float x)
    {
        StartCoroutine(WaitHit());
        movement.Hit(x);
    }

    private IEnumerator WaitHit()
    {
        if (dead)
            yield break;
        movement.canMove = false;
        yield return new WaitForSeconds(0.2f);
        movement.canMove = true;
    }

    public override void Die()
    {

        base.Die();
        dead = true;
        movement.canMove = false;
    }

    public void updateStatus(int partType)
    {
        if (partType == 0)
        {
            if (partsManager.headParts[partsNum[0]].partsHealth + defaultHealth >= maxHealth)
            {
                health = partsManager.headParts[partsNum[0]].partsHealth + health;
                maxHealth = partsManager.headParts[partsNum[0]].partsHealth + defaultHealth;
            }
            else
            {
                maxHealth = partsManager.headParts[partsNum[0]].partsHealth + defaultHealth;
                if (maxHealth < health)
                    health = maxHealth;
            }
        }
        else if (partType == 1)
        {
            attDamage = partsManager.armParts[partsNum[1]].partsDamage + defaultDamage;
            attSpeed = partsManager.armParts[partsNum[1]].partsAttSpeed + defaultAttSpeed;
            attRange = partsManager.armParts[partsNum[1]].attRange;
            attType = partsManager.armParts[partsNum[1]].partsType;
        }
        else if (partType == 2)
        {
            dash = partsManager.legParts[partsNum[2]].dash;
            jumpCount = partsManager.legParts[partsNum[2]].jumpCount;
            moveSpeed = partsManager.legParts[partsNum[2]].partsMoveSpeed;
            jumpForce = partsManager.legParts[partsNum[2]].jumpForce;
        }
    }
}
