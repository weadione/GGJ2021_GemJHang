using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootingUI : MonoBehaviour
{

    public GameObject head;
    public GameObject arm;
    public GameObject leg;

    public Sprite[] headSprite;
    public Sprite[] armSprite;
    public Sprite[] legSprite;

    private bool can=false;

    public int[] returnValue;
    public int[] itemList;

    public PartsManager partsManager;
 
    public void start()
    {
        returnValue = new int[2];
    }

    public void printroot(int[] itemlist)
    {
        this.itemList = itemlist;



        //if (!(itemlist[0] == 0))
        //    head.GetComponent<Image>().sprite = headSprite[itemlist[0]];

        //if (!(itemlist[1] == 0))
        //    arm.GetComponent<Image>().sprite = armSprite[itemlist[1]];

        //if (!(itemlist[2] == 0))
        //    leg.GetComponent<Image>().sprite = legSprite[itemlist[2]];
        Debug.Log("실행");
        can = true;

        
    }

    private void Update()
    {
        if (can)
        {
            partsManager.selectParts = itemList;
            partsManager.selectParts[3] = 1;
   
        }
    }

    public int[] select1()
    {
        Debug.Log("dfksdfdsfsadfsdafsdafsdafs");
        returnValue[0] = 0;
        returnValue[1] = itemList[0];
        return itemList;
    }
    public int[] select2()
    {
        returnValue[0] = 1;
        returnValue[1] = itemList[1];
        return itemList;
    }
    public int[] select3()
    {
        returnValue[0] = 2;
        returnValue[1] = itemList[2];
        return itemList;
    }

}
