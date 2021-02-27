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

    public GameObject descHead;
    public GameObject descArm;
    public GameObject descLeg;

    public GameObject[] healthArrows;
    public GameObject[] attArrows;
    public GameObject[] attSpeedArrows;
    public GameObject[] attRangeArrows;
    public GameObject[] moveSpeedArrows;

    public GameObject headPanel;
    public GameObject armPanel;
    public GameObject legPanel;

    public GameObject PlayerImageCamera;

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


        //머리 파츠 관련 출력
        if (!(itemlist[0] == 0))
        {

            //head.SetActive(true);
            //descHead.SetActive(true);
            headPanel.SetActive(true);

            //체력 상중하 표시
            if (partsManager.headParts[itemlist[0]].partsHealth<=50)
            {
                healthArrows[1].SetActive(false);
                healthArrows[2].SetActive(false);
            }
            else if(partsManager.headParts[itemlist[0]].partsHealth > 50 && partsManager.headParts[itemlist[0]].partsHealth <= 75)
            {
                healthArrows[1].SetActive(true);
                healthArrows[2].SetActive(false);
            }
            else
            {
                healthArrows[1].SetActive(true);
                healthArrows[2].SetActive(true);
            }

            //파츠 이미지 출력
            head.GetComponent<Image>().sprite = partsManager.headList[itemlist[0]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            headPanel.SetActive(false);
            //head.SetActive(false);
            //descHead.SetActive(false);
            //head.GetComponent<Image>().sprite = noImage;
        }

        //팔 파츠 관련 출력
        if (!(itemlist[1] == 0))
        {
            //arm.SetActive(true);
            //descArm.SetActive(true);
            armPanel.SetActive(true);

            //공격력 상중하 표시
            if(partsManager.armParts[itemlist[1]].partsDamage<=20)
            {
                attArrows[1].SetActive(false);
                attArrows[2].SetActive(false);
            }
            else if (partsManager.armParts[itemlist[1]].partsDamage > 20 && partsManager.armParts[itemlist[1]].partsDamage <= 40)
            {
                attArrows[1].SetActive(true);
                attArrows[2].SetActive(false);
            }
            else
            {
                attArrows[1].SetActive(true);
                attArrows[2].SetActive(true);
            }

            //공속 상중하 표시
            if (partsManager.armParts[itemlist[1]].partsAttSpeed >= 0.5f)
            {
                attSpeedArrows[1].SetActive(false);
                attSpeedArrows[2].SetActive(false);
            }
            else if (partsManager.armParts[itemlist[1]].partsAttSpeed <= 0.4f && partsManager.armParts[itemlist[1]].partsAttSpeed >= 0.3f)
            {
                attSpeedArrows[1].SetActive(true);
                attSpeedArrows[2].SetActive(false);
            }
            else
            {
                attSpeedArrows[1].SetActive(true);
                attSpeedArrows[2].SetActive(true);
            }

            //사거리 상중하 표시
            if (partsManager.armParts[itemlist[1]].partsType)   //근거리(기본팔이 '하'임)
            {
                attRangeArrows[1].SetActive(true);
                attRangeArrows[2].SetActive(false);
            }
            else
            {
                attRangeArrows[1].SetActive(true);
                attRangeArrows[2].SetActive(true);
            }

            arm.GetComponent<Image>().sprite = partsManager.armList[itemlist[1]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {

            armPanel.SetActive(false);
            //arm.SetActive(false);
            //descArm.SetActive(false);
            //arm.GetComponent<Image>().sprite = noImage;
        }

        //다리 파츠 관련 출력
        if (!(itemlist[2] == 0))
        {
            legPanel.SetActive(true);
            //leg.SetActive(true);
            //descLeg.SetActive(true);

            if (partsManager.legParts[itemlist[2]].partsMoveSpeed <= 6)
            {
                moveSpeedArrows[1].SetActive(false);
                moveSpeedArrows[2].SetActive(false);
            }
            else if(partsManager.legParts[itemlist[2]].partsMoveSpeed >= 7 && partsManager.legParts[itemlist[2]].partsMoveSpeed <= 8)
            {
                moveSpeedArrows[1].SetActive(true);
                moveSpeedArrows[2].SetActive(false);
            }
            else
            {
                moveSpeedArrows[1].SetActive(true);
                moveSpeedArrows[2].SetActive(true);
            }

            leg.GetComponent<Image>().sprite = partsManager.legList[itemlist[2]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            legPanel.SetActive(false);
            //leg.SetActive(false);
            //descLeg.SetActive(false);
            //leg.GetComponent<Image>().sprite = noImage;
        }

        can = true;
        //PlayerImageCamera.SetActive(true);

    }


    private void Start()
    {
        PlayerState.Instance.GetComponentInChildren<Rooting>().rootUI = gameObject;
        gameObject.SetActive(false);
    }



    public void select1()
    {
        Debug.Log("dfksdfdsfsadfsdafsdafsdafs");
        returnValue = new int[2];
        returnValue[0] = 0;
        returnValue[1] = itemList[0];
        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        monsterBody.SetActive(false);
        PlayerImageCamera.SetActive(false);
    }
    public void select2()
    {
        returnValue = new int[2];
        returnValue[0] = 1;
        returnValue[1] = itemList[1];
        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        monsterBody.SetActive(false);
        PlayerImageCamera.SetActive(false);
    }
    public void select3()
    {
        returnValue = new int[2];
        returnValue[0] = 2;
        returnValue[1] = itemList[2];
        partsManager.ChangeParts(returnValue[0], returnValue[1]);
        monsterBody.SetActive(false);
        PlayerImageCamera.SetActive(false);
    }

}
