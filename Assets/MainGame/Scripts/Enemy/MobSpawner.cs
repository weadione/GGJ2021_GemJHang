﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public EnemyManager enemyManager;

    public int[] mobList;
    public GameObject left;
    public GameObject right;
    public GameObject tracer;
    public GameObject telepotePos;

    public int selectPattern;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        Spawn();
    }



    private void Spawn()
    {
        if (selectPattern == 1)
        {
            for (int i = 0; i < mobList.Length; i++)
            {
                GameObject monster = Instantiate(enemyManager.enemyList[mobList[i]], transform.position, transform.rotation);
                monster.transform.parent = transform;
                monster.GetComponent<EnemyPattern>().left = left;
                monster.GetComponent<EnemyPattern>().right = right;
                monster.GetComponent<EnemyPattern>().SelectPattern(1);
                GameManager.Instance.monsterRemain++;
            }
        }
        else if(selectPattern==2)
        {
            for (int i = 0; i < mobList.Length; i++)
            {
                GameObject monster = Instantiate(enemyManager.enemyList[mobList[i]], transform.position, transform.rotation);
                monster.transform.parent = transform;
                monster.GetComponent<EnemyPattern>().left = left;
                monster.GetComponent<EnemyPattern>().right = right;
                monster.GetComponent<EnemyPattern>().Tracer = tracer.GetComponent<BoxCollider2D>();
                monster.GetComponent<EnemyPattern>().SelectPattern(2);
                GameManager.Instance.monsterRemain++;
            }
        }
        else if (selectPattern == 3)
        {
            for (int i = 0; i < mobList.Length; i++)
            {
                GameObject monster = Instantiate(enemyManager.enemyList[mobList[i]], transform.position, transform.rotation);
                monster.transform.parent = transform;
                monster.GetComponent<EnemyPattern>().left = left;
                monster.GetComponent<EnemyPattern>().right = right;
                monster.GetComponent<EnemyPattern>().Tracer = tracer.GetComponent<BoxCollider2D>();
                monster.GetComponent<EnemyPattern>().SelectPattern(3);
                GameManager.Instance.monsterRemain++;
            }
        }
        else if (selectPattern == 4)
        {
            for (int i = 0; i < mobList.Length; i++)
            {
                GameObject monster = Instantiate(enemyManager.enemyList[mobList[i]], transform.position, transform.rotation);
                monster.transform.parent = transform;
                monster.GetComponent<EnemyPattern>().left = left;
                monster.GetComponent<EnemyPattern>().right = right;
                monster.GetComponent<EnemyPattern>().Tracer = tracer.GetComponent<BoxCollider2D>();
                monster.GetComponent<EnemyPattern>().teleportPos = telepotePos.transform.position;
                monster.GetComponent<EnemyPattern>().SelectPattern(4);
                GameManager.Instance.monsterRemain++;
            }
        }
    }
}
