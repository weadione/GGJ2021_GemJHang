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
    public CapsuleCollider2D damageZone;

    public float animalAdaptationTmp;
    public float machineAdaptationTmp;


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
        GetComponent<PartsManager>().initalize();
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        partsNum = new int[3];
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        //attDamage = 1000f;   //10
        //health = 100f;     //100
        //attType = false;
        //attSpeed = 0.1f;    //1f 
        //moveSpeed = 10f;    //5
        //dashSpeed = 30f;
        //attRange = 3f;
        //maxHealth = 100f;

        //jumpCount = 1;
        dash = false;
        //jumpForce = 600;    //400

        defaultDamage = 10f;
        defaultHealth = 100f;
        defaultAttType = true;
        defaultAttSpeed = 1f;
        defaultMoveSpeed = 5f;
        defaultDashSpeed = 30f;

    }


    private void Start()
    {
        //
        //partsNum[0] = 0;
        //partsNum[1] = 0;
        //partsNum[2] = 0;
        partsManager = GetComponent<PartsManager>();
        movement = GetComponent<CharacterMovement>();
        lastAttTime = 0f;


        animalAdaptationTmp = 0f;
        machineAdaptationTmp = 0f;


    }







    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        GetComponent<HitEffect>().RunEffect();    
        
    }

    private void Update()
    {
        //Debug.Log(health);

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
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameManager.Instance.animalPartsAdaptation += animalAdaptationTmp;
        GameManager.Instance.machinePartsAdaptation += machineAdaptationTmp;
        GameManager.Instance.AdaptationSave();
        GameManager.Instance.isGameover = true;
    }


    public void updateStatus(int partType)
    {

        if (partType == 0)
        {
            if (partsManager.headParts[partsNum[0]].adaptation == 1)
            {
                animalAdaptationTmp += 0.05f;
                if (partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.animalPartsAdaptation + defaultHealth >= maxHealth)
                {
                    health = partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.animalPartsAdaptation + health;
                    maxHealth = partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.animalPartsAdaptation + defaultHealth;
                }
                else
                {
                    maxHealth = partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.animalPartsAdaptation + defaultHealth;
                    if (maxHealth < health)
                        health = maxHealth;
                }
            }
            else if(partsManager.headParts[partsNum[0]].adaptation == 2)
            {
                machineAdaptationTmp += 0.05f;
                if (partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.machinePartsAdaptation + defaultHealth >= maxHealth)
                {
                    health = partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.machinePartsAdaptation + health;
                    maxHealth = partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.machinePartsAdaptation + defaultHealth;
                }
                else
                {
                    maxHealth = partsManager.headParts[partsNum[0]].partsHealth * GameManager.Instance.machinePartsAdaptation + defaultHealth;
                    if (maxHealth < health)
                        health = maxHealth;
                }
            }
        }
        else if (partType == 1)
        {
            if (partsManager.armParts[partsNum[1]].adaptation == 1)
            {
                animalAdaptationTmp += 0.05f;
                attDamage = partsManager.armParts[partsNum[1]].partsDamage * GameManager.Instance.animalPartsAdaptation + defaultDamage;
                attSpeed = partsManager.armParts[partsNum[1]].partsAttSpeed + defaultAttSpeed;
                attRange = partsManager.armParts[partsNum[1]].attRange;
                attType = partsManager.armParts[partsNum[1]].partsType;
                damageZone.size = new Vector2(attRange, 2);
            }
            else if (partsManager.armParts[partsNum[1]].adaptation == 2)
            {
                machineAdaptationTmp += 0.05f;
                attDamage = partsManager.armParts[partsNum[1]].partsDamage * GameManager.Instance.machinePartsAdaptation + defaultDamage;
                attSpeed = partsManager.armParts[partsNum[1]].partsAttSpeed + defaultAttSpeed;
                attRange = partsManager.armParts[partsNum[1]].attRange;
                attType = partsManager.armParts[partsNum[1]].partsType;
                damageZone.size = new Vector2(attRange, 2);
            }

        }
        else if (partType == 2)
        {
            if (partsManager.legParts[partsNum[2]].adaptation == 1)
            {
                animalAdaptationTmp += 0.05f;
                dash = partsManager.legParts[partsNum[2]].dash;
                jumpCount = partsManager.legParts[partsNum[2]].jumpCount;
                moveSpeed = partsManager.legParts[partsNum[2]].partsMoveSpeed * GameManager.Instance.animalPartsAdaptation;
                jumpForce = partsManager.legParts[partsNum[2]].jumpForce;
            }
            else if (partsManager.legParts[partsNum[2]].adaptation == 2)
            {
                machineAdaptationTmp += 0.05f;
                dash = partsManager.legParts[partsNum[2]].dash;
                jumpCount = partsManager.legParts[partsNum[2]].jumpCount;
                moveSpeed = partsManager.legParts[partsNum[2]].partsMoveSpeed * GameManager.Instance.machinePartsAdaptation;
                jumpForce = partsManager.legParts[partsNum[2]].jumpForce;
            }
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
        }

        
    }
}
