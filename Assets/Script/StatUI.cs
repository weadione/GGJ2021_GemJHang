using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
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

    //public GameObject headPanel;
    //public GameObject armPanel;
    //public GameObject legPanel;

    public GameObject PlayerImageCamera;

    public Sprite noImage;


    private bool can = false;

    public int[] returnValue;
    public int[] itemList;

    public PartsManager partsManager;



    public void printroot()
    {
        this.itemList = PlayerState.Instance.partsNum;


        //머리 파츠 관련 출력
        if (!(itemList[0] == 0))
        {

            //head.SetActive(true);
            //descHead.SetActive(true);
            //headPanel.SetActive(true);

            //체력 상중하 표시
            if (partsManager.headParts[itemList[0]].partsHealth <= 50)
            {
                healthArrows[1].SetActive(false);
                healthArrows[2].SetActive(false);
            }
            else if (partsManager.headParts[itemList[0]].partsHealth > 50 && partsManager.headParts[itemList[0]].partsHealth <= 75)
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
            head.GetComponent<Image>().sprite = partsManager.headList[itemList[0]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
           // headPanel.SetActive(false);
            //head.SetActive(false);
            //descHead.SetActive(false);
            head.GetComponent<Image>().sprite = noImage;
            healthArrows[1].SetActive(false);
            healthArrows[2].SetActive(false);
        }

        //팔 파츠 관련 출력
        if (!(itemList[1] == 0))
        {
            //arm.SetActive(true);
            //descArm.SetActive(true);
            //armPanel.SetActive(true);

            //공격력 상중하 표시
            if (partsManager.armParts[itemList[1]].partsDamage <= 20)
            {
                attArrows[1].SetActive(false);
                attArrows[2].SetActive(false);
            }
            else if (partsManager.armParts[itemList[1]].partsDamage > 20 && partsManager.armParts[itemList[1]].partsDamage <= 40)
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
            if (partsManager.armParts[itemList[1]].partsAttSpeed >= 0.5f)
            {
                attSpeedArrows[1].SetActive(false);
                attSpeedArrows[2].SetActive(false);
            }
            else if (partsManager.armParts[itemList[1]].partsAttSpeed <= 0.4f && partsManager.armParts[itemList[1]].partsAttSpeed >= 0.3f)
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
            if (partsManager.armParts[itemList[1]].partsType)   //근거리(기본팔이 '하'임)
            {
                attRangeArrows[1].SetActive(true);
                attRangeArrows[2].SetActive(false);
            }
            else
            {
                attRangeArrows[1].SetActive(true);
                attRangeArrows[2].SetActive(true);
            }

            arm.GetComponent<Image>().sprite = partsManager.armList[itemList[1]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
           // armPanel.SetActive(false);
            //arm.SetActive(false);
            //descArm.SetActive(false);
            arm.GetComponent<Image>().sprite = noImage;
            attArrows[1].SetActive(false);
            attArrows[2].SetActive(false);
            attSpeedArrows[1].SetActive(false);
            attSpeedArrows[2].SetActive(false);
            attRangeArrows[1].SetActive(false);
            attRangeArrows[2].SetActive(false);
        }

        //다리 파츠 관련 출력
        if (!(itemList[2] == 0))
        {
            //legPanel.SetActive(true);
            //leg.SetActive(true);
            //descLeg.SetActive(true);

            if (partsManager.legParts[itemList[2]].partsMoveSpeed <= 6)
            {
                moveSpeedArrows[1].SetActive(false);
                moveSpeedArrows[2].SetActive(false);
            }
            else if (partsManager.legParts[itemList[2]].partsMoveSpeed >= 7 && partsManager.legParts[itemList[2]].partsMoveSpeed <= 8)
            {
                moveSpeedArrows[1].SetActive(true);
                moveSpeedArrows[2].SetActive(false);
            }
            else
            {
                moveSpeedArrows[1].SetActive(true);
                moveSpeedArrows[2].SetActive(true);
            }

            leg.GetComponent<Image>().sprite = partsManager.legList[itemList[2]].GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            //legPanel.SetActive(false);
            //leg.SetActive(false);
            //descLeg.SetActive(false);
            leg.GetComponent<Image>().sprite = noImage;
            moveSpeedArrows[1].SetActive(false);
            moveSpeedArrows[2].SetActive(false);
        }

        can = true;
        PlayerImageCamera.SetActive(true);

    }


    private void Update()
    {
        printroot();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }
}
