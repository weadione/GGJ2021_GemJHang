using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

    public int selectNum; // 사용자의 선택지 넘버
    public Text text;
    public int scriptNum; // ses에 의해서 증가함(ses가 확인하면 그에 따라서 변화를 일으키는 조건
    public GameObject[] button;
    public int selectStep; // 시작 == 0, 스크립트 클릭하여 변화가 일어나면 1씩 증가(사용자 클릭 확인)
    public int battle;      // 0-> 노싸움, 1-> 싸움시작 2-> 싸움 끝

    string nameScene;
    int stageTier = -1;
    int stageNo = -1;
    int randomValue;
    int randomParts;

    public PartsManager PM;



    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        nameScene = SceneManager.GetActiveScene().name;

        stageTier = nameScene[0];
        stageNo = nameScene[2] - '0';
        Debug.Log("EventManagerLOG stageName : " +nameScene);
        PM = PlayerState.Instance.GetComponent<PartsManager>();
        selectStep = 0;
        selectNum = 0;
        scriptNum = 0;
    }



    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void Start()
    {
        PM = PlayerState.Instance.GetComponent<PartsManager>();
    }

    private void Awake()
    {
        nameScene = SceneManager.GetActiveScene().name;
        Debug.Log("EventManagerLOG stageName : " + nameScene);
        stageTier = nameScene[0];
        stageNo = nameScene[2] - '0';
        

        DontDestroyOnLoad(gameObject);
        selectStep = 0;
        selectNum = 0;
        scriptNum = 0;

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
        if(stageTier == 69) // E 아스키코드값
        {
            if (stageNo == 0) // Ev0
            {
                EV0RunEvent();
            }
            else if (stageNo == 1) //EV1
            {
                EV1RunEvent();
            }
            else if (stageNo == 2) // EV2
            {
                EV2RunEvent();
            }
            else if (stageNo == 3) // EV3
            {
                EV3RunEvent();
            }
            else if (stageNo == 4) // EV4
            {
                EV4RunEvent();
            }
            else if (stageNo == 5)
            {
                EV5RunEvent();
            }
            else if (stageNo == 6)
            {
                EV6RunEvent();
            }
            else if(stageNo ==7)
            {
                EV7RunEvent();
            }
            else if(stageNo ==8)
            {
                EV8RunEvent();
            }
        }

    }

    public void EV8RunEvent()
    {
        if(scriptNum ==1)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
            button[2].SetActive(true);
            button[3].SetActive(true);
            randomValue = Random.Range(1, 10);
            randomParts = Random.Range(1, 8);
        }
        else if(scriptNum ==2)
        {
            text.text = "프린터기가 크게 흔들리며 굉음을 내기 시작했습니다.\n당신은 불길한 예감이 들고 있습니다.";
            selectStep = 2;
        }
        else if(scriptNum ==3)
        {
            text.text = "프린터기에서 큰 소리와 함께 연기가 나오다가 서서히 작동을 멈춥니다.\n녹슨 프린터기 따위를 믿는게 아니었습니다.";
            selectStep = 3;
        }
        else if(scriptNum ==4)
        {
            text.text = "당신은 허전해진 신체 부위와 고장난 프린터기를 하염 없이 바라보다 어쩔 수 없이 그냥 떠나기로 했습니다.";
            selectStep = 4;
        }
        else if(scriptNum ==5)
        {
            SceneManager.LoadScene("WorldScene");
        }
        else if(scriptNum ==6)
        {
            text.text = "프린터기가 크게 흔들리며 새로운 신체를 만들고 있습니다.\n 소리가 서서히 작아집니다.\n당신은 좋은 결과물을 기다리고있습니다.";
            selectStep = 6;
        }
        else if(scriptNum ==7)
        {
            text.text = "당신은 프린터기에서 나온 새 신체를 좋은 마음으로 장착합니다.";
            selectStep = 4;
        }
        if(selectNum ==1)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 거대한 프린터기에 머리를 집어 넣었습니다.";
            if(randomValue <4)
            {
                selectStep = 1;
                PM.ChangeParts(0, 0);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(0, 0); // 실제로 테스트해봐야함
            }
            else 
            {
                selectStep = 5;
                PM.ChangeParts(0, randomParts);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(0, randomParts); // 실제로 테스트해봐야함
            }

            scriptNum = 0;
            selectNum = 0;
        }
        else if(selectNum ==2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 거대한 프린터기에 팔를 집어 넣었습니다.";
            if (randomValue < 4)
            {
                selectStep = 1;
                PM.ChangeParts(1, 0);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(1, 0); // 실제로 테스트해봐야함

            }
            else
            {
                selectStep = 5;
                PM.ChangeParts(1, randomParts);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(1, randomParts); // 실제로 테스트해봐야함
            }
            scriptNum = 0;
            selectNum = 0;
        }
        else if (selectNum == 3)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 거대한 프린터기에 다리를 집어 넣었습니다.";
            if (randomValue < 4)
            {
                selectStep = 1;
                PM.ChangeParts(2, 0);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(2, 0); // 실제로 테스트해봐야함
            }
            else
            {
                selectStep = 5;
                if (randomParts == 0)
                {
                    PM.ChangeParts(2, randomParts);
                    // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(2, randomParts); // 실제로 테스트해봐야함
                }
                else
                {
                    PM.ChangeParts(2, randomParts+1);
                    // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(2, randomParts+1); // 실제로 테스트해봐야함
                }
            }
            scriptNum = 0;
            selectNum = 0;
        }
        else if (selectNum == 4)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 녹슨 3D 프린터를 무시하고 지나갑니다.";
            scriptNum = 0;
            selectNum = 0;
            selectStep = 4;

        }
    }


    public void EV7RunEvent()
    {
        
        if (scriptNum ==1)
        {
            button[0].SetActive(true);
            randomValue = Random.Range(0, 99);
        }    
        else if(scriptNum ==2)
        {
            text.text = "돌림판이 힘차게 돌아갑니다!";
            selectStep = 2;
        }
        else if(scriptNum ==3)
        {
            text.text = "과연 당신의 결과는??";
            selectStep = 3;
        }        
        else if(scriptNum ==4)
        {
            
            if(randomValue ==0)
            {
                text.text = "죽음입니다!!";
                selectStep = 4;
            }
            else if(0<randomValue && randomValue<10)
            {
                text.text = "회복에 당첨되셨습니다!!";
                //PlayerState.Instance.         //실제로 테스트해봐야함
                selectStep = 5;
            }
            else if(9<randomValue && randomValue<40)
            {
                text.text = "머리 손실!";
                PM.ChangeParts(0,0);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(0, 0); // 실제로 테스트해봐야함
                selectStep = 5;
            }
            else if(39<randomValue && randomValue <70)
            {
                text.text = "팔 손실!";
                PM.ChangeParts(1,0);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(1, 0); // 실제로 테스트해봐야함
                selectStep = 5;
            }
            else if (69 < randomValue && randomValue < 100)
            {
                text.text = "다리 손실!";
                PM.ChangeParts(2, 0);
                // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(2, 0); // 실제로 테스트해봐야함
                selectStep = 5;
            }
        }
        else if(scriptNum ==5)
        {
            PlayerState.Instance.OnDamage(10000);
        }
        else if(scriptNum ==6)
        {
            SceneManager.LoadScene("WorldScene");
        }

        if(selectNum ==1)
        {
            button[0].SetActive(false);
            text.text = "                        -확률표-\n죽음(1%), 회복(9%), 머리손실(30%), 팔손실(30%), 다리손실(30%)";
            scriptNum = 0;
            selectNum = 0;
            selectStep = 1;
        }

    }


    public void EV6RunEvent()
    {
        if(scriptNum ==1)
        {
            //if (PlayerState.Instance.partsNum[0] != 0)  //실제로 테스트 해야함
                button[0].SetActive(true);
            //if (PlayerState.Instance.partsNum[1] != 0)
                button[1].SetActive(true);
            //if (PlayerState.Instance.partsNum[2] != 0)
                button[2].SetActive(true);

            button[3].SetActive(true);
        }
        else if(scriptNum ==2)
        {
            SceneManager.LoadScene("WorldScene");
        }

        if(selectNum ==1)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 당신의 머리를 제단 위로 올렸습니다.\n엄청난 빛이 난 후에 당신의 머리는 흔적도 없이 사라졌습니다.";

            Debug.Log("PM은 실행");
            // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(0, 0);  //실제로 테스트 해봐야함
            scriptNum = 0;
            selectNum = 0;
            selectStep = 1;
            //PM.ChangeParts(0, 3);
            PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(0, 3);

        }
        else if(selectNum ==2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 당신의 팔을 제단 위로 올렸습니다.\n엄청난 빛이 난 후에 당신의 팔은 흔적도 없이 사라졌습니다.";
            PM.ChangeParts(1, 0);
            // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(1, 0); // 실제로 테스트해봐야함
            scriptNum = 0;
            selectNum = 0;
            selectStep = 1;


        }
        else if (selectNum == 3)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 당신의 다리를 제단 위로 올렸습니다.\n엄청난 빛이 난 후에 당신의 다리는 흔적도 없이 사라졌습니다.";
            PM.ChangeParts(2, 0);
            // PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(2, 0); // 실제로 테스트해봐야함
            scriptNum = 0;
            selectNum = 0;
            selectStep = 1;
        }
        else if (selectNum == 4)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            button[2].SetActive(false);
            button[3].SetActive(false);
            text.text = "당신은 몸에 상처를 내 제단에 피를 뿌렸습니다.\n엄청난 빛이 난 후에 제단 위의 피는 말끔히 사라졌습니다.";
           // PlayerState.Instance.health               //실제로 테스트 해봐야함
            scriptNum = 0;
            selectNum = 0;
            selectStep = 1;
        }


    }



    public void EV5RunEvent()
    {
        if(scriptNum ==1)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
        }
        else if(scriptNum ==2)
        {
            SceneManager.LoadScene("EV5_BS1");
        }
        else if(scriptNum ==3)
        {
            text.text = "괴성을 듣고 경비 로봇이 출동하였습니다.";
            selectStep = 3;
        }
        else if(scriptNum ==4)
        {
            SceneManager.LoadScene("EV5_BS2");
        }

        if(selectNum ==1)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신은 갇혀있던 생물들을 해방했지만, 생물들은 화가 많이 나보입니다.";
            selectStep = 1;
            scriptNum = 0;
            selectNum = 0;

        }
        else if(selectNum ==2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신은 갇혀있는 생물들을 무시하며 지나갑니다.\n그런 당신의 행동을 보고 생물들이 괴성를 지릅니다";
            selectStep = 2;
            scriptNum = 0;
            selectNum = 0;

        }



    }





    public void EV4RunEvent()
    {
        if(scriptNum == 1)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
        }
        else if(scriptNum ==2)
        {
            text.text = "그 실험의 내용은 모든 생물과 기계를 합쳐 어우를 수 있는 완전생물에 대한 내용이었습니다.";
            selectStep = 2;
        }
        else if(scriptNum ==3)
        {
            text.text = "당신은 공책을 읽자 알 수 없는 불쾌감과 분노가 차올랐습니다.";
            selectStep = 3;
        }

        else if(scriptNum ==4)
        {
            text.text = "그런 당신에게 생물체가 물약을 건네줍니다.\n물약을 마시자 강해진 기분이 듭니다.";
           // PlayerState.Instance.defaultDamage += 50;       //실제로 테스트해야함
            selectStep = 4;
            
        }
        else if(scriptNum ==5)
        {
            SceneManager.LoadScene("WorldScene");
        }
        else if(scriptNum ==6)
        {
            SceneManager.LoadScene("EV4_BS");
        }



        if(selectNum == 1)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            if(true)//(GameManager.Instance.animalPartsAdaptation >=1.5f)       //실제로 테스트해야함
            {
                text.text = "생물체에게 말을 거니, 이 생물체가 한 공책을 보여줍니다.\n공책에는 어떤 실험에 대한 이야기가 적혀있습니다.";
                selectStep = 1;
            }
            else
            {
                text.text = "당신이 말을 걸자, 생물체가 지하 수로 끝자락까지 도망쳤습니다.";
                selectStep = 4;
            }
            selectNum = 0;
            scriptNum = 0;
        }
        else if(selectNum == 2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신은 괴상한 생물체를 공격합니다.";
            selectStep = 5;
            selectNum = 0;
            scriptNum = 0;
        }


    }


    public void EV3RunEvent()
    {
        if(scriptNum == 1)
        {
            button[0].SetActive(true);
        }
        else if(scriptNum ==2)
        {
            SceneManager.LoadScene("WorldScene");
        }    
        else if(scriptNum == 3)
        {
            text.text = "대장 말이 당신에게 돌진하였습니다.";
            selectStep = 3;
        }
        else if(scriptNum ==4)
        {
            SceneManager.LoadScene("EV3_BS");
        }

        if(selectNum == 1)
        {
            button[0].SetActive(false);
            if (true)//(GameManager.Instance.machinePartsAdaptation >= 1.5f) //실제로 테스트해야함
            {
                text.text = "당신은 대장 말과 친구가 되었습니다.\n 대장 말은 자신의 친구에게 축복을 내려주었습니다.";
                // PlayerState.Instance.defaultDamage += 20;        //실제로 테스트해야함
                // PlayerState.Instance.defaultAttSpeed -= 0.2f;
                // PlayerState.Instance.machineAdaptationTmp += 0.1f;
                selectStep = 1;
            }
            else
            {
                text.text = "대장 말이 당신에게 적대감을 표출합니다.";
                selectStep = 2;
            }
            selectNum = 0;
            scriptNum = 0;
        }

    }



    public void EV2RunEvent()
    {
        if(scriptNum == 1)
        {
            button[0].SetActive(true);
        }
        else if(scriptNum == 2)
        {
            text.text = "쓰레기통 로봇이 당신에게 자신의 팔을 선물합니다.";
            selectStep = 3;
        }
        else if(scriptNum == 3)
        {
            text.text = "쓰레기통 로봇이 바닥에 쓰레기를 던진 당신을 응징합니다.";
            selectStep = 4;
        }
        else if(scriptNum ==4)
        {
            //    PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(1, 5); // 후반 쓰레기팔로 바꿈//실제로 테스트해야함
            SceneManager.LoadScene("WorldScene");
        }
        else if(scriptNum == 5)
        {
            SceneManager.LoadScene("EV2_BS");
        }

        if(selectNum == 1)
        {
            button[0].SetActive(false);
            if(false)//(PlayerState.Instance.partsNum[1] == 4 || PlayerState.Instance.partsNum[1] == 5 || PlayerState.Instance.partsNum[2] == 8 || PlayerState.Instance.partsNum[2] == 9)//실제로 테스트해야함
            {
                //쓰레기통 파츠 보유시
                text.text = "당신은 완벽하게 쓰레기를 던져 쓰레기통 안으로 넣었습니다.\n쓰레기통 로봇이 만족한 표정을 짓습니다.";
                selectStep = 1;
                selectNum = 0;
                scriptNum = 0;
            }
            else
            {
                //쓰레기통 파츠 미보유시
                text.text = "손이 미끄러져서 쓰레기가 쓰레기통에 들어가지 않았습니다.\n당신은 바닥에 쓰레기를 버렸습니다.\n쓰레기통 로봇이 굉장히 화가 나보입니다.";
                selectStep = 2;
                selectNum = 0;
                scriptNum = 0;
            }
        }
    }



    
    
    public void EV1RunEvent() // ses 0-> 스크립트 1-> 선택지 ON 2-> 전투 3-> 송충이 저주 4-> 탈출
    {

        if(scriptNum == 1)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);
        }
        else if(scriptNum == 2)
        {
            SceneManager.LoadScene("EV1_BS");
        }
        else if(scriptNum == 3)
        {

            text.text = "당신은 송충이의 저주를 받았습니다.";
            //PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(1, 1); // 송충이팔로 변함 //실제로 테스트해야함
            Debug.Log("저주당.");
            selectStep = 3;
        }
        else if(scriptNum == 4)
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
            selectStep = 1;


        }
        else if(selectNum == 2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신의 괴롭힘으로 불쌍한 송충이가 죽었습니다.";
            selectNum = 0;                                      //선택값 초기화
            scriptNum = 0;                                      //안하면 선택지 안사라짐
            selectStep = 2;

        }




    }















    


    public void EV0RunEvent() //ses 0 -> 선택지ON 1-> 전투 2->탈출 
    {
        Debug.Log("이벤트로는 들어옴" + scriptNum);
        if (scriptNum == 1)
        {
            button[0].SetActive(true);
            button[1].SetActive(true);

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


        if (selectNum == 1)
        {
            if(true)//(PlayerState.Instance.partsNum[0] == 2) // 플레이어 머리파츠가 뱀 머리(2) 일때  //실제로 테스트해야함
            {
                button[0].SetActive(false);
                button[1].SetActive(false);
                text.text = "당신은 뱀의 친구가 되었습니다.";
                
                if(PlayerState.Instance.health+30 < PlayerState.Instance.maxHealth) // 체력회복 30  //실제로 테스트해야함
                {
                    PlayerState.Instance.health += 20;
                }
                else
                {
                    PlayerState.Instance.health = PlayerState.Instance.maxHealth;
                }
                selectStep = 2;



            }
            else
            {
                button[0].SetActive(false);
                button[1].SetActive(false);
                Debug.Log("뱀습격");
                text.text = "당신은 뱀들에게 습격당했습니다.";
                selectStep = 1;


            }
            selectNum = 0;
            scriptNum = 0;

        }
        else if (selectNum == 2)
        {
            button[0].SetActive(false);
            button[1].SetActive(false);
            text.text = "당신은 뱀굴을 지나칩니다.";

            Debug.Log("2번 전달 완료~");
            selectStep = 2;
            selectNum = 0;
            scriptNum = 0;
        }


    }



}


