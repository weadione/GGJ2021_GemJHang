using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour
{
    public GameObject[] armList;
    public GameObject[] legList;
    public GameObject[] headList;

    public Parts[] armParts;
    public Parts[] legParts;
    public Parts[] headParts;
    public bool tmp = true;


    // Start is called before the first frame update
    void Start()
    {
        initalize();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tmp)
        {
            ChangeParts(0, 2);
            ChangeParts(1, 6);
            ChangeParts(2, 7);
            tmp = false;
        }

    }

    public void initalize()
    {
        armParts = new Parts[9];
        legParts = new Parts[10];
        headParts = new Parts[9];

        //체력, 뎀지, 근/원거리, 공속, 이속, 이름, 사거리, 대쉬여부, 점프카운트, 점프력
        armParts[0] = new Parts(0f, 10f, true, 1f, 0f, "default", 7, false, 1, 0);          //기본
        armParts[1] = new Parts(0f, 20f, true, 1f, 0f, "bug", 9,false,1,0);                 //송충이 
        armParts[2] = new Parts(0f, 15f, false, 0.9f, 0f, "slime1", 3, false, 1,0);         //슬라임1        
        armParts[3] = new Parts(0f, 25f, false, 0.8f, 0f, "slime2", 3, false, 1, 0);        //슬라임2
        armParts[4] = new Parts(0f, 12f, false, 0.8f, 0f, "trashRobot1", 3, false, 1, 0);   //쓰레기통1
        armParts[5] = new Parts(0f, 22f, false, 0.7f, 0f, "trashRobot2", 3, false, 1, 0);   //쓰레기통2
        armParts[6] = new Parts(0f, 36f, false, 0.6f, 0f, "centaur", 3, false, 1, 0);       //켄타우로스
        armParts[7] = new Parts(0f, 50f, true, 0.7f, 0f, "chainsaw1", 11, false, 1, 0);      //전기톱1
        armParts[8] = new Parts(0f, 85f, true, 1.2f, 0f, "chainsaw2", 11, false, 1, 0);      //전기톱2


        legParts[0] = new Parts(0f, 0f, true, 0f, 10f, "default", 0, false, 1, 400);         //기본
        legParts[1] = new Parts(0f, 0f, true, 0f, 12f, "snake1",0, false, 1, 400);           //뱀1
        legParts[2] = new Parts(0f, 0f, true, 0f, 15f, "snake2", 0, false, 1, 420);          //뱀2
        legParts[3] = new Parts(0f, 0f, true, 0f, 13f, "snake3", 0, false, 2, 410);          //뱀3
        legParts[4] = new Parts(0f, 0f, true, 0f, 14f, "bumper1", 0, false, 1, 400);         //범퍼카1
        legParts[5] = new Parts(0f, 0f, true, 0f, 9f, "bumper2", 0, true, 1, 400);           //범퍼카2
        legParts[6] = new Parts(0f, 0f, true, 0f, 10f, "woodHorse1", 0, false, 1, 420);      //목마1
        legParts[7] = new Parts(0f, 0f, true, 0f, 13f, "woodHorse2", 0, false, 2, 410);      //목마2
        legParts[8] = new Parts(0f, 0f, true, 0f, 13f, "trashRobot1", 0, false, 1, 410);     //쓰레기통1
        legParts[9] = new Parts(0f, 0f, true, 0f, 15f, "trashRobot2", 0, false, 1, 420);     //쓰레기통2


        headParts[0] = new Parts(0f, 0f, true, 0f, 0f, "default", 0, false, 1, 0);          //기본
        headParts[1] = new Parts(50f, 0f, true, 0f, 0f, "bug", 0, false, 1, 0);             //송충이
        headParts[2] = new Parts(50f, 0f, true, 0f, 0f, "snake1", 0, false, 1, 0);          //뱀1
        headParts[3] = new Parts(75f, 0f, true, 0f, 0f, "snake2", 0, false, 1, 0);          //뱀2
        headParts[4] = new Parts(100f, 0f, true, 0f, 0f, "snake3", 0, false, 1, 0);         //뱀3
        headParts[5] = new Parts(50f, 0f, true, 0f, 0f, "slime1", 0, false, 1, 0);          //슬라임1
        headParts[6] = new Parts(100f, 0f, true, 0f, 0f, "slime2", 0, false, 1, 0);         //슬라임2
        headParts[7] = new Parts(50f, 0f, true, 0f, 0f, "bumper1", 0, false, 1, 0);         //범퍼카1
        headParts[8] = new Parts(100f, 0f, true, 0f, 0f, "bumper2", 0, false, 1, 0);        //범퍼카2





        for (int i = 0; i < armList.Length; i++)
            armParts[i].mainObject = armList[i];

        for (int i = 0; i < legList.Length; i++)
            legParts[i].mainObject = legList[i];

        for (int i = 0; i < headList.Length; i++)
            headParts[i].mainObject = headList[i];
    }

    public void ChangeParts(int partsType, int changeNum)   //partsType: 파츠타입, changNum: 원하는 파츠의 번호
    {
        if(partsType==0)    //머리
        {

            headParts[PlayerState.Instance.partsNum[0]].mainObject.SetActive(false);
            headParts[changeNum].mainObject.SetActive(true);
            PlayerState.Instance.partsNum[0] = changeNum;
            PlayerState.Instance.updateStatus(0);
        }
        else if(partsType == 1)    //팔
        {
            armParts[PlayerState.Instance.partsNum[1]].mainObject.SetActive(false);
            armParts[changeNum].mainObject.SetActive(true);
            PlayerState.Instance.partsNum[1] = changeNum;
            PlayerState.Instance.updateStatus(1);
        }
        else if (partsType == 2)    //다리
        {
            legParts[PlayerState.Instance.partsNum[2]].mainObject.SetActive(false);
            legParts[changeNum].mainObject.SetActive(true);
            PlayerState.Instance.partsNum[2] = changeNum;
            PlayerState.Instance.updateStatus(2);
        }
        else
        {
            Debug.LogError("ChangeParts 오류!");
        }

        

    }


}
