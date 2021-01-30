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

    public string[] sceneName;

    public int monsterRemain;
    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        initialzeScene();
        monsterRemain = 0;
    }

    private void Update()
    {
        startGame();
    }

    public void startGame()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneManager.LoadScene(sceneName[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene(sceneName[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneManager.LoadScene(sceneName[2]);
        }
    }

    public void initialzeScene()
    {
        sceneName = new string[3];
        sceneName[0] = "GameStart";
        sceneName[1] = "GameEnd";
        sceneName[2] = "testscenes";
    }


}
