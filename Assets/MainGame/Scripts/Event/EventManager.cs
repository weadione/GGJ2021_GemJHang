using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private static GameObject instance;
    public int selectNum; // 사용자의 선택지 넘버
    public Text text;
    public int scriptNum; // ses에 의해서 증가함(ses가 확인하면 그에 따라서 변화를 일으키는 조건
    public GameObject[] button;
    public int selectStep; // 시작 == 0, 스크립트 클릭하여 변화가 일어나면 1씩 증가(사용자 클릭 확인)
    public int battle;      // 0-> 노싸움, 1-> 싸움시작 2-> 싸움 끝

    string nameScene;
    int stageTier = -1;
    int stageNo = -1;
    

    public static GameObject Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                instance = GameObject.FindWithTag("DontDestroy");
            }

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        nameScene = SceneManager.GetActiveScene().name;

        stageTier = nameScene[0];
        stageNo = nameScene[2] - '0';
        Debug.Log("LOG: STAGETIER : " + stageTier + "   STAGENO : " + stageNo);

        selectStep = 0;
        selectNum = 0;
        scriptNum = 0;
    }

    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    private void Awake()
    {
        selectNum = 0;
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this.gameObject;
        selectStep = 0;
        DontDestroyOnLoad(gameObject);

    }


    private void Update()
    {
        Debug.Log("ses  " + selectStep + "scn  " + scriptNum + "sec   " + selectNum);

        SelectOn();
        RunEvent();
        
    }
    public void SelectOn()
    {

    }


    public void RunEvent()
    {
        if(stageTier == 69) // A 아스키코드값
        {
            if(stageNo == 0) // A0
            {
                EV0RunEvent();
            }
            if(stageNo == 1)
            {
                EV1RunEvent();
            }

        }

    }
    
    
    public void EV1RunEvent() // ses 0-> 스크립트 1-> 선택지 ON 2-> 전투 3-> 송충이 저주 4-> 탈출
    {
        if(scriptNum == 1)
        {
            text.text = "어라? 송충이들 중 몸집이 작은 한 마리가 괴롭힘 당하고 있습니다.";
            selectStep = 1;
        }
        else if(scriptNum == 2)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
        }
        else if(scriptNum == 3)
        {
            SceneManager.LoadScene("A1_Battle");
        }
        else if(scriptNum == 4)
        {

            text.text = "당신은 송충이의 저주를 받았습니다.";
            Debug.Log("저주당.");
            selectStep = 4;
        }
        else if(scriptNum == 5)
        {
            SceneManager.LoadScene("WorldScene");
        }
        if(selectNum == 1)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신은 송충이 세 마리에게 달려들었습니다.";
            selectNum = 0;                                      //선택값 초기화
            scriptNum = 0;                                      //안하면 선택지 안사라짐
            selectStep = 2;


        }
        else if(selectNum == 2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신의 괴롭힘으로 불쌍한 송충이가 죽었습니다.";
            selectNum = 0;                                      //선택값 초기화
            scriptNum = 0;                                      //안하면 선택지 안사라짐
            selectStep = 3;

        }




    }















    


    public void EV0RunEvent() //ses 0 -> 선택지ON 1-> 전투 2->탈출 
    {
        Debug.Log("이벤트로는 들어옴" + scriptNum);
        if (scriptNum == 1)
        {
            Debug.Log("SCN은 1임");
            button[0].SetActive(true);
            button[1].SetActive(true);
            Debug.Log("SCN은 1맞음");
            scriptNum = 0;
        }
        else if (scriptNum == 2)
        {
            Debug.Log("싸우러가자");
            
            SceneManager.LoadScene("EV0_BS");
        }
        else if(scriptNum == 3)
        {
            SceneManager.LoadScene("WorldScene");
        }
        if(battle ==1)
        {
            

        }

        if (selectNum == 1)
        {
            if(PlayerState.Instance.partsNum[0] == 2) // 플레이어 머리파츠가 뱀 머리(2) 일때
            {
                text.text = "당신은 뱀의 친구가 되었습니다.";
                
                if(PlayerState.Instance.health+30 < PlayerState.Instance.maxHealth) // 체력회복 30
                {
                    PlayerState.Instance.health += 20;
                }
                else
                {
                    PlayerState.Instance.health = PlayerState.Instance.maxHealth;
                }
                selectStep = 2;
                button[0].SetActive(false);
                button[1].SetActive(false);


            }
            else
            {
                Debug.Log("뱀습격");
                text.text = "당신은 뱀들에게 습격당했습니다.";
                selectStep = 1;
                button[0].SetActive(false);
                button[1].SetActive(false);

            }
            selectNum = 0;
            scriptNum = 0;

        }
        else if (selectNum == 2)
        {
            text.text = "당신은 뱀굴을 지나칩니다.";
            button[0].SetActive(false);
            button[1].SetActive(false);
            Debug.Log("2번 전달 완료~");
            selectStep = 2;
            selectNum = 0;
        }
        else if (selectNum == 3)
        {
            Debug.Log("3번 전달 완료~");
            selectNum = 0;
        }
        else if (selectNum == 4)
        {
            Debug.Log("4번 전달 완료~");
            selectNum = 0;
        }




    }



}


