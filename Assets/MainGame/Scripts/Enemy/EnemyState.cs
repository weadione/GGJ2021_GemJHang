using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{
    public EnemyMovement enemyMove;
    public float lastAttTime;

    int playerLayer, enemyLayer, footLayer, enemyFootLayer, detecterLayer, playBulletLayer, monsterBulletLayer;

    public int[] item;  //드랍할 파츠

    public Animator attackAnimator;
    public GameObject monsterBullet;

    public GameObject deadIcon;

    float tmpDamage, tmpHealth, tmpattSpeed, tmpmoveSpeed;
    //bool tmp

    //protected override void OnEnable()
    //{
    //    base.OnEnable();

    //    attDamage = 10f;
    //    health = 100f;
    //    attType = true;
    //    attSpeed = 1f;
    //    moveSpeed = 5f;
    //    dashSpeed = 30f;
    //    Debug.LogError(attDamage);

    //}

    public void changeState(float health, float damage, bool attType,float attSpeed, float moveSpeed,int[] item)
    {
        this.attDamage = damage;
        this.health = health;
        this.attType = attType;
        this.attSpeed = attSpeed;
        this.moveSpeed = moveSpeed;
        this.item = item;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (!dead &&Time.time>=lastAttTime+attSpeed)
            {

                LivingEntity target = other.GetComponent<LivingEntity>();

               
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                PlayerState.Instance.HitDetect(GetComponent<Rigidbody2D>().velocity.x);
                attackAnimator.SetTrigger("attackTrigger");
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            if (!dead && Time.time >= lastAttTime + attSpeed)
            {
                LivingEntity target = other.GetComponent<LivingEntity>();
                target.OnDamage(attDamage);
                lastAttTime = Time.time;
                PlayerState.Instance.HitDetect(GetComponent<Rigidbody2D>().velocity.x);
                attackAnimator.SetTrigger("attackTrigger");
            }
        }
    }

    public void DistanceAttack()
    {
        if (attType)
            return;

        if(Time.time>=lastAttTime+attSpeed)
        {
            GameObject tmpBullet = Instantiate(monsterBullet, transform.position, transform.rotation);
            tmpBullet.GetComponent<MonsterBullet>().damage = attDamage;
            tmpBullet.GetComponent<Rigidbody2D>().velocity = transform.localScale.x >= 0 ? new Vector2(-10, 0) : new Vector2(10, 0);
            tmpBullet.transform.localScale = transform.localScale.x >= 0 ? tmpBullet.transform.localScale : new Vector3(-tmpBullet.transform.localScale.x, tmpBullet.transform.localScale.y, tmpBullet.transform.localScale.z);
            lastAttTime = Time.time;
            attackAnimator.SetTrigger("attackTrigger");
        }

    }


    public void HitDetect(float x)
    {
        StartCoroutine(WaitHit());
        enemyMove.Hit(x);
    }

    private IEnumerator WaitHit()
    {
        if (dead)
            yield break;
        enemyMove.canMove = false;
        yield return new WaitForSeconds(0.2f);
        enemyMove.canMove = true;
    }


    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
        GetComponent<HitEffect>().RunEffect();

    }

    private void Start()
    {
        lastAttTime = Time.time;
        enemyMove = GetComponent<EnemyMovement>();
        //StartCoroutine(UpdateMove());

        //item = new int[3];

        enemyFootLayer = LayerMask.NameToLayer("EnemyFoot");
        detecterLayer = LayerMask.NameToLayer("Detecter");
        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        footLayer = LayerMask.NameToLayer("PlayerFoot");
        playBulletLayer = LayerMask.NameToLayer("Bullet");
        monsterBulletLayer = LayerMask.NameToLayer("MonsterBullet");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyFootLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, enemyFootLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, enemyLayer, true);
        Physics2D.IgnoreLayerCollision(footLayer, detecterLayer, true);
        Physics2D.IgnoreLayerCollision(playerLayer, detecterLayer, true);
        Physics2D.IgnoreLayerCollision(enemyFootLayer, enemyFootLayer, true);
        Physics2D.IgnoreLayerCollision(enemyFootLayer, playBulletLayer, true);
        Physics2D.IgnoreLayerCollision(monsterBulletLayer, enemyLayer, true);
        Physics2D.IgnoreLayerCollision(monsterBulletLayer, enemyFootLayer, true);
        Physics2D.IgnoreLayerCollision(monsterBulletLayer, detecterLayer, true);
        Physics2D.IgnoreLayerCollision(monsterBulletLayer, monsterBulletLayer, true);
        Physics2D.IgnoreLayerCollision(monsterBulletLayer, footLayer, true);
    }
    private void Update()
    {
        enemyMove.Direction();
        DistanceAttack();


    }

    private IEnumerator UpdateMove()
    {
        while(true)
        {
            enemyMove.moveSpeed = 5f;
            yield return new WaitForSeconds(1.0f);
            enemyMove.moveSpeed = -5f;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public override void Die()
    {

        base.Die();
        dead = true;
        enemyMove.canMove = false;
        tag = "Dead";
        Destroy(GetComponent<Rigidbody2D>());
        GameManager.Instance.monsterRemain--;

        Instantiate(Resources.Load("Prefeb/DeadIcon"), new Vector2(transform.GetChild(0).transform.position.x, transform.position.y + 1.9f), transform.rotation);
        
    }
}
