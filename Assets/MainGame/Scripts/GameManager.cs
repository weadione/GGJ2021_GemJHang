using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        //저장된 값들 초기화하는 함수. 세이브&로드 관련해서 오류가 발생해서 꼬이거나 적응도 리셋 원할시 아래 함수를 1번만 실행 후 다시 주석 처리 할 것
        PlayerPrefs.DeleteAll();

        monsterRemain = 0;
        playerParts = new int[3];
        isGameover = false;
        Load();
    }

    public GameObject exitButton;
    public GameObject gameoverText;

    //적응도 변수
    public float animalPartsAdaptation;
    public float machinePartsAdaptation;

    //게임오버 유/무
    public bool isGameover;


    //플레이어 스텟 변수들(세이브 로드용)->사용 안 할수도
    private float playerAttDamage;
    private float playerHealth;
    private bool playerAttType;
    private float playerAttSpped;
    private float playerMoveSpeed;
    private float playerDashSpeed;
    private float playerAttRange;
    private float playerJumpForce;
    private int[] playerParts;
    private int jumpcount;

    //스테이지 클리어 확인 관련 변수
    public int monsterRemain;
    public bool canExit = false;

    public void Save()
    {
        //플레이어 상태 관련
        PlayerPrefs.SetFloat("PlayerAttDamage", PlayerState.Instance.attDamage);
        PlayerPrefs.SetFloat("PlayerHealth", PlayerState.Instance.health);
        PlayerPrefs.SetFloat("PlayerAttSpeed", PlayerState.Instance.attSpeed);
        PlayerPrefs.SetFloat("PlayerMoveSpeed", PlayerState.Instance.moveSpeed);
        PlayerPrefs.SetFloat("PlayerDashSpeed", PlayerState.Instance.dashSpeed);
        PlayerPrefs.SetFloat("PlayerAttRange", PlayerState.Instance.attRange);
        PlayerPrefs.SetFloat("PlayerJumpForce", PlayerState.Instance.jumpForce);
        PlayerPrefs.SetInt("PlayerJumpCount", PlayerState.Instance.jumpCount);
        PlayerPrefs.SetFloat("AnimalAdaptationTmp", PlayerState.Instance.animalAdaptationTmp);
        PlayerPrefs.SetFloat("MachineAdaptationTmp", PlayerState.Instance.machineAdaptationTmp);

        PlayerPrefs.SetFloat("PlayerDefaultDamage", PlayerState.Instance.defaultDamage);
        PlayerPrefs.SetFloat("PlayerDefaultAttSpeed", PlayerState.Instance.defaultAttSpeed);
        PlayerPrefs.SetFloat("PlayerDefaultMoveSpeed", PlayerState.Instance.defaultMoveSpeed);


        PlayerPrefs.SetFloat("PlayerHeadHealth", PlayerState.Instance.headPartsHealth);
        if (PlayerState.Instance.isHeadParts)
            PlayerPrefs.SetInt("IsPlayerHeadParts", 1); //머리파츠 장착중
        else
            PlayerPrefs.SetInt("IsPlayerHeadParts", 0); //머리파츠 미장착(기본머리)


        if (PlayerState.Instance.attType)
            PlayerPrefs.SetInt("PlayerAttType", 1); //근거리
        else
            PlayerPrefs.SetInt("PlayerAttType", 0); //원거리


        PlayerPrefs.SetInt("PlayerHeadParts", PlayerState.Instance.partsNum[0]);
        PlayerPrefs.SetInt("PlayerArmParts", PlayerState.Instance.partsNum[1]);
        PlayerPrefs.SetInt("PlayerLegParts", PlayerState.Instance.partsNum[2]);



        //맵 관련
        PlayerPrefs.SetInt("MapCurrent", ChangePosiitonScript.cur);

        for (int i = 0; i < ChangePosiitonScript.isVisited.GetLength(0); i++)
        {
            for (int j = 0; j < ChangePosiitonScript.isVisited.GetLength(1); j++)
            {
                if (ChangePosiitonScript.isVisited[i, j])
                    PlayerPrefs.SetInt("MapIsVisited" + i.ToString() + "," + j.ToString(), 1);  //true
                else
                    PlayerPrefs.SetInt("MapIsVisited" + i.ToString() + "," + j.ToString(), 0);  //false
            }
        }
    }

    public void AdaptationSave()
    {
        PlayerPrefs.SetFloat("AnimalAdaptation", animalPartsAdaptation);
        PlayerPrefs.SetFloat("MachineAdaptation", machinePartsAdaptation);
    }

    public void ResetSave()
    {
        //플레이어 상태 관련
        PlayerPrefs.SetFloat("PlayerAttDamage", 10f);
        PlayerPrefs.SetFloat("PlayerHealth", 100f);
        PlayerPrefs.SetFloat("PlayerAttSpeed", 0.5f);
        PlayerPrefs.SetFloat("PlayerMoveSpeed",10f);
        PlayerPrefs.SetFloat("PlayerDashSpeed", 30f);
        PlayerPrefs.SetFloat("PlayerAttRange",3f);
        PlayerPrefs.SetFloat("PlayerJumpForce", 400f);
        PlayerPrefs.SetInt("PlayerJumpCount", 1);
        PlayerPrefs.SetFloat("AnimalAdaptationTmp", 0f);
        PlayerPrefs.SetFloat("MachineAdaptationTmp", 0f);

        PlayerPrefs.SetFloat("PlayerDefaultDamage", 10f);
        PlayerPrefs.SetFloat("PlayerDefaultAttSpeed", 1f);
        PlayerPrefs.SetFloat("PlayerDefaultMoveSpeed", 5f);

        PlayerPrefs.SetFloat("PlayerHeadHealth", 0f);
        PlayerPrefs.SetInt("IsPlayerHeadParts", 0); //머리파츠 미장착

        PlayerPrefs.SetInt("PlayerAttType", 1); //근거리

        PlayerState.Instance.GetComponent<PartsManager>().ResetParts();

        PlayerPrefs.SetInt("PlayerHeadParts", 0);
        PlayerPrefs.SetInt("PlayerArmParts", 0);
        PlayerPrefs.SetInt("PlayerLegParts", 0);



        //맵 관련
        PlayerPrefs.SetInt("MapCurrent", 0);

        for (int i = 0; i < ChangePosiitonScript.isVisited.GetLength(0); i++)
        {
            for (int j = 0; j < ChangePosiitonScript.isVisited.GetLength(1); j++)
            {
                PlayerPrefs.SetInt("MapIsVisited" + i.ToString() + "," + j.ToString(), 0);  //false
            }
        }
    }

   public void Load()
    {
        //플레이어 상태 관련
        PlayerState.Instance.attDamage = PlayerPrefs.GetFloat("PlayerAttDamage", 10f);
        PlayerState.Instance.health = PlayerPrefs.GetFloat("PlayerHealth", 100f);
        PlayerState.Instance.attSpeed = PlayerPrefs.GetFloat("PlayerAttSpeed", 0.5f);
        PlayerState.Instance.moveSpeed = PlayerPrefs.GetFloat("PlayerMoveSpeed", 10f);
        PlayerState.Instance.dashSpeed = PlayerPrefs.GetFloat("PlayerDashSpeed", 30f);
        PlayerState.Instance.attRange = PlayerPrefs.GetFloat("PlayerAttRange", 3f);
        PlayerState.Instance.jumpForce = PlayerPrefs.GetFloat("PlayerJumpForce", 400f);
        PlayerState.Instance.jumpCount= PlayerPrefs.GetInt("PlayerJumpCount", 1);
        PlayerState.Instance.animalAdaptationTmp = PlayerPrefs.GetFloat("AnimalAdaptationTmp", 0f);
        PlayerState.Instance.machineAdaptationTmp = PlayerPrefs.GetFloat("MachineAdaptationTmp", 0f);

        PlayerState.Instance.defaultDamage = PlayerPrefs.GetFloat("PlayerDefaultDamage", 10f);
        PlayerState.Instance.defaultAttSpeed= PlayerPrefs.GetFloat("PlayerDefaultAttSpeed", 1f);
        PlayerState.Instance.defaultMoveSpeed = PlayerPrefs.GetFloat("PlayerDefaultMoveSpeed", 5f);


        animalPartsAdaptation = PlayerPrefs.GetFloat("AnimalAdaptation", 1f);
        machinePartsAdaptation = PlayerPrefs.GetFloat("MachineAdaptation", 1f);

        PlayerState.Instance.headPartsHealth = PlayerPrefs.GetFloat("PlayerHeadHealth", 0f);
        if (PlayerPrefs.GetInt("IsPlayerHeadParts", 0) == 0)
            PlayerState.Instance.isHeadParts = false;   //머리파츠 미장착
        else
            PlayerState.Instance.isHeadParts = true;    //머리파츠 장착중


        if (PlayerPrefs.GetInt("PlayerAttType", 1) == 1)
            PlayerState.Instance.attType = true;    //근거리
        else
            PlayerState.Instance.attType = false;   //원거리

  
        PlayerState.Instance.partsNum[0] = PlayerPrefs.GetInt("PlayerHeadParts", 0);
        PlayerState.Instance.partsNum[1] = PlayerPrefs.GetInt("PlayerArmParts", 0);
        PlayerState.Instance.partsNum[2] = PlayerPrefs.GetInt("PlayerLegParts", 0);

        PlayerState.Instance.GetComponent<PartsManager>().LoadParts();

        //맵 관련
        ChangePosiitonScript.cur = PlayerPrefs.GetInt("MapCurrent", 0);

        for (int i = 0; i < ChangePosiitonScript.isVisited.GetLength(0); i++)
        {
            for (int j = 0; j < ChangePosiitonScript.isVisited.GetLength(1); j++)
            {
                if (PlayerPrefs.GetInt("MapIsVisited" + i.ToString() + "," + j.ToString(), 0) == 1)
                    ChangePosiitonScript.isVisited[i, j] = true;
                else
                    ChangePosiitonScript.isVisited[i, j] = false;
            }
        }
    }

    //죽으면 Gameover됨
    public void ReturnTitle()
    {
        if (isGameover)
        {
            gameoverText.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                ResetSave();
                Load();
                PlayerState.Instance.dead = false;
                isGameover = false;
                PlayerState.Instance.GetComponent<CharacterMovement>().canMove = true;
                gameoverText.SetActive(false);
                SceneManager.LoadScene("TitleScene");
            }
        }
    }



    private void Update()
    {
        exitGame();
        ReturnTitle();
        //Debug.Log("동물"+monsterRemain);
    }

    private void exitGame()
    { 
        
        if(Input.GetKeyDown(KeyCode.E) && canExit)
        {
            canExit = false;
            exitButton.SetActive(true);
        }
    }




}
