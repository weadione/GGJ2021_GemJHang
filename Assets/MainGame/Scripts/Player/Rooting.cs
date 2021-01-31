﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooting : MonoBehaviour
{

    public bool click = false;
    int[] rootItemList;
    int[] selectItem;

    public PartsManager tmp;

    public GameObject rootUI;
    //public Animator rootkAnimator;


    private void Start()
    {
        rootItemList = new int[3];
        selectItem = new int[2];
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Dead")
        {
            if (!PlayerState.Instance.dead && click)
            {
                EnemyState enemyState = other.GetComponent<EnemyState>();
                click = false;
                rootItemList = enemyState.item;
                //rootUI.SetActive(true);
                tmp.ChangeParts(0, 1);
                //rootUI.GetComponent<LootingUI>().printroot(rootItemList);
            }
        }
    }






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !click)
        {

            click = true;
            StartCoroutine(WaitAttack());
            //rootUI.GetComponent<LootingUI>().printroot(new int[3] {1,2,3 });
        }
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.1f);
        click = false;
    }
}
