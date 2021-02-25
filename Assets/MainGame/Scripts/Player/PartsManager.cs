using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartsManager : MonoBehaviour
{
    public GameObject[] armList;
    public GameObject[] legList;
    public GameObject[] headList;

    public Parts[] armParts;
    public Parts[] legParts;
    public Parts[] headParts;
    public bool tmp = true;

    public GameObject lootUI;
    // Start is called before the first frame update


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded: " + scene.name);
        initalize();
    }



    public void initalize()
    {
        armParts = new Parts[9];
        legParts = new Parts[10];
        headParts = new Parts[9];

        //체력, 뎀지, 근/원거리, 공속, 이속, 이름, 사거리, 대쉬여부, 점프카운트, 점프력, 파츠의 타입(동물, 기계)

        armParts[0] = new Parts(0f, 10f, true, 0.4f, 0f, "default", 3, false, 1, 0, 0);          //기본
        armParts[1] = new Parts(0f, 15f, true, 0.3f, 0f, "bug", 6, false, 1, 0, 1);                 //송충이 
        armParts[2] = new Parts(0f, 10f, false, 0.4f, 0f, "slime1", 3, false, 1, 0, 1);         //슬라임1        
        armParts[3] = new Parts(0f, 20f, false, 0.4f, 0f, "slime2", 3, false, 1, 0, 1);        //슬라임2
        armParts[4] = new Parts(0f, 5f, false, 0.05f, 0f, "trashRobot1", 3, false, 1, 0, 2);   //쓰레기통1
        armParts[5] = new Parts(0f, 20f, false, 0.05f, 0f, "trashRobot2", 3, false, 1, 0, 2);   //쓰레기통2
        armParts[6] = new Parts(0f, 31f, false, 0.4f, 0f, "centaur", 3, false, 1, 0, 1);       //켄타우로스
        armParts[7] = new Parts(0f, 45f, true, 0.1f, 0f, "chainsaw1", 9, false, 1, 0, 2);    //전기톱1
        armParts[8] = new Parts(0f, 70f, true, 0.4f, 0f, "chainsaw2", 9, false, 1, 0, 2);     //전기톱2


        legParts[0] = new Parts(0f, 0f, true, 0f, 5f, "default", 0, false, 2, 400, 0);         //기본
        legParts[1] = new Parts(0f, 0f, true, 0f, 6f, "snake1",0, false, 2, 400,1);           //뱀1
        legParts[2] = new Parts(0f, 0f, true, 0f, 8f, "snake2", 0, false, 2, 420,1);          //뱀2
        legParts[3] = new Parts(0f, 0f, true, 0f, 11f, "snake3", 0, false, 3, 410,1);          //뱀3
        legParts[4] = new Parts(0f, 0f, true, 0f, 9f, "bumper1", 0, false, 2, 400,2);         //범퍼카1
        legParts[5] = new Parts(0f, 0f, true, 0f, 12f, "bumper2", 0, true, 2, 400,2);           //범퍼카2
        legParts[6] = new Parts(0f, 0f, true, 0f, 6f, "woodHorse1", 0, false, 2, 420,2);      //목마1
        legParts[7] = new Parts(0f, 0f, true, 0f, 8f, "woodHorse2", 0, false, 3, 410,2);      //목마2
        legParts[8] = new Parts(0f, 0f, true, 0f, 8f, "trashRobot1", 0, false, 2, 410,2);     //쓰레기통1
        legParts[9] = new Parts(0f, 0f, true, 0f, 11f, "trashRobot2", 0, false, 2, 420,2);     //쓰레기통2



        headParts[0] = new Parts(0f, 0f, true, 0f, 0f, "default", 0, false, 1, 0,0);          //기본
        headParts[1] = new Parts(50f, 0f, true, 0f, 0f, "bug", 0, false, 1, 0,1);             //송충이
        headParts[2] = new Parts(50f, 0f, true, 0f, 0f, "snake1", 0, false, 1, 0,1);          //뱀1
        headParts[3] = new Parts(75f, 0f, true, 0f, 0f, "snake2", 0, false, 1, 0,1);          //뱀2
        headParts[4] = new Parts(100f, 0f, true, 0f, 0f, "snake3", 0, false, 1, 0,1);         //뱀3
        headParts[5] = new Parts(50f, 0f, true, 0f, 0f, "slime1", 0, false, 1, 0,1);          //슬라임1
        headParts[6] = new Parts(100f, 0f, true, 0f, 0f, "slime2", 0, false, 1, 0,1);         //슬라임2
        headParts[7] = new Parts(50f, 0f, true, 0f, 0f, "bumper1", 0, false, 1, 0,2);         //범퍼카1
        headParts[8] = new Parts(75f, 0f, true, 0f, 0f, "bumper2", 0, false, 1, 0,2);        //범퍼카2





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
        
        lootUI.SetActive(false);
        

    }

    public void ResetParts()
    {
        headParts[PlayerState.Instance.partsNum[0]].mainObject.SetActive(false);
        headParts[0].mainObject.SetActive(true);

        armParts[PlayerState.Instance.partsNum[1]].mainObject.SetActive(false);
        armParts[0].mainObject.SetActive(true);

        legParts[PlayerState.Instance.partsNum[2]].mainObject.SetActive(false);
        legParts[0].mainObject.SetActive(true);
    }

    public void LoadParts()
    {
        headParts[0].mainObject.SetActive(false);
        headParts[PlayerState.Instance.partsNum[0]].mainObject.SetActive(true);

        armParts[0].mainObject.SetActive(false);
        armParts[PlayerState.Instance.partsNum[1]].mainObject.SetActive(true);

        legParts[0].mainObject.SetActive(false);
        legParts[PlayerState.Instance.partsNum[2]].mainObject.SetActive(true);
    }

}
