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



    // Start is called before the first frame update
    void Start()
    {
        initalize();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void initalize()
    {
        armParts = new Parts[2];
        legParts = new Parts[2];
        headParts = new Parts[1];

        //체력, 뎀지, 근/원거리, 공속, 이속, 이름, 사거리, 대쉬여부, 점프카운트, 점프력
        armParts[0] = new Parts(0f, 10f, true, 1f, 0f, "bug", 6,false,1,0);
        armParts[1] = new Parts(0f, 20f, true, 1f, 0f, "elephant", 6, false, 1,0);


        legParts[0] = new Parts(0f, 0f, true, 0f, 10f, "snake",0, false, 1, 400);
        legParts[1] = new Parts(0f, 0f, true, 0f, 15f, "horse",0, false, 1, 400);

        headParts[0] = new Parts(50f, 0f, true, 0f, 0f, "bug",0, false, 1, 0);

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
