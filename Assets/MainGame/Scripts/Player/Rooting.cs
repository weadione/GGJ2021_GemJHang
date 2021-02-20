using System.Collections;
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
                Debug.Log("루팅");
                EnemyState enemyState = other.GetComponent<EnemyState>();
                rootItemList = enemyState.item;
                Debug.Log(rootItemList[0]);
                Debug.Log(rootItemList[1]);
                Debug.Log(rootItemList[2]);
                //if (rootItemList[0] != 0)
                //{
                //    tmp.ChangeParts(0, rootItemList[0]);
                //}
                //if (rootItemList[1] != 0)
                //{
                //    tmp.ChangeParts(1, rootItemList[1]);
                //}
                //if (rootItemList[2] != 0)
                //{
                //    tmp.ChangeParts(2, rootItemList[2]);
                //}
                

                
                click = false;
  
                rootUI.SetActive(true);
                rootUI.GetComponent<LootingUI>().PlayerImageCamera.SetActive(true);
                //tmp.ChangeParts(0, 1);
                rootUI.GetComponent<LootingUI>().printroot(rootItemList, other.gameObject);
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
