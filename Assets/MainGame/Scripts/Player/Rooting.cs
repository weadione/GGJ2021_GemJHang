using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooting : MonoBehaviour
{

    public bool click = false;
    int[] rootItemList;

    //public Animator rootkAnimator;


    private void Start()
    {
        rootItemList = new int[3];
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
                //uimanager.instance.printroot(rootItemList);
                //rootAnimator.SetTrigger("root");

            }
        }
    }

    void printroot(int[] itemlist)
    {
        //UI 띄우고 선택받은값 x, y
        //changeParts(x, y);

    }




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !click)
        {

            click = true;
            StartCoroutine(WaitAttack());

        }
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.1f);
        click = false;
    }
}
