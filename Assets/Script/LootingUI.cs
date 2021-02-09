using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LootingUI : MonoBehaviour
{

    public GameObject head;
    public GameObject arm;
    public GameObject leg;

    public Sprite noImage;


    private bool can=false;

    public int[] returnValue;
    public int[] itemList;

    public PartsManager partsManager;
    public GameObject monsterBody;



    public void printroot(int[] itemlist, GameObject monsterBody)
    {
        this.itemList = itemlist;
        this.monsterBody = monsterBody;


        if (!(itemlist[0] == 0))
        {
            //head.SetActive(true);
            
            head.GetComponent<Image>().sprite = partsManager.headList[itemlist[0]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            head.GetComponent<Image>().sprite = noImage;
        }

        if (!(itemlist[1] == 0))
        {
            //arm.SetActive(true);

            arm.GetComponent<Image>().sprite = partsManager.armList[itemlist[1]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            //arm.SetActive(false);
            arm.GetComponent<Image>().sprite = noImage;
        }

        if (!(itemlist[2] == 0))
        {
            //leg.SetActive(true);
            
            leg.GetComponent<Image>().sprite = partsManager.legList[itemlist[2]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            leg.GetComponent<Image>().sprite = noImage;
        }

        can = true;

        
    }


    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //if (can)
        //{ 
        //    if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {

        //        returnValue = new int[2];
        //        returnValue[0] = 0;
        //        returnValue[1] = itemList[0];
        //        //Debug.Log(returnValue[1]);
        //        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        //        can = false;

        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {

        //        returnValue = new int[2];
        //        returnValue[0] = 1;
        //        returnValue[1] = itemList[1];
        //        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        //        can = false;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {

        //        returnValue = new int[2];
        //        returnValue[0] = 2;
        //        returnValue[1] = itemList[2];
        //        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        //        can = false;
        //    }
        //}
    }

    public void select1()
    {
        Debug.Log("dfksdfdsfsadfsdafsdafsdafs");
        returnValue = new int[2];
        returnValue[0] = 0;
        returnValue[1] = itemList[0];
        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        monsterBody.SetActive(false);
    }
    public void select2()
    {
        returnValue = new int[2];
        returnValue[0] = 1;
        returnValue[1] = itemList[1];
        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        monsterBody.SetActive(false);
    }
    public void select3()
    {
        returnValue = new int[2];
        returnValue[0] = 2;
        returnValue[1] = itemList[2];
        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        monsterBody.SetActive(false);
    }

}
