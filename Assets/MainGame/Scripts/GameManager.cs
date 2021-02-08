using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject exitButton;

    public float animalPartsAdaptation;
    public float machinePartsAdaptation;

    public int currentStage;

    public string[] sceneName;

    public int monsterRemain;
    public bool canExit = false;

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        monsterRemain = 0;
    }

    private void Start()
    {
        currentStage = 0;
    }

    private void Update()
    {
        exitGame();
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
