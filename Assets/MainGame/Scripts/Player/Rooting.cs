using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooting : MonoBehaviour
{

    public bool click = false;
    int[] rootItemList;

=======
    int[] selectItem;
    int input;
    public PartsManager tmp;

    public GameObject rootUI;
    public GameObject LootingManager;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
                Debug.Log("루팅");
                click = false;
>>>>>>> Stashed changes
                EnemyState enemyState = other.GetComponent<EnemyState>();
                click = false;
                rootItemList = enemyState.item;
<<<<<<< Updated upstream
                //uimanager.instance.printroot(rootItemList);
                //rootAnimator.SetTrigger("root");

=======
                LootingManager.SetActive(true);
                LootingManager.GetComponent<LootingManager>().Select(rootItemList);

                
                
  
                //rootUI.SetActive(true);
                //tmp.ChangeParts(0, 1);
                //rootUI.GetComponent<LootingUI>().printroot(rootItemList);
>>>>>>> Stashed changes
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
        if (Input.GetKeyDown(KeyCode.Z) && !click)
        {

            click = true;
            input = 0;
            StartCoroutine(WaitAttack());
            //rootUI.GetComponent<LootingUI>().printroot(new int[3] {1,2,3 });
        }
        else if (Input.GetKeyDown(KeyCode.X) && !click)
        {

            click = true;
            input = 1;
            StartCoroutine(WaitAttack());
            //rootUI.GetComponent<LootingUI>().printroot(new int[3] {1,2,3 });
        }
        else if (Input.GetKeyDown(KeyCode.C) && !click)
        {

            click = true;
            input = 2;
            StartCoroutine(WaitAttack());

        }
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(0.1f);
        click = false;
    }
}
