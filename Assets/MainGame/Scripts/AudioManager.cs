using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    string nameScene;
    int stageTier = -1;
    int stageNo = -1;
    public AudioClip[] audioClipArr;
    public AudioSource audioSource;
    int currentAudio;

    private static GameObject instance;
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

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this.gameObject;
        audioSource = GetComponent<AudioSource>();
        currentAudio = -1;
        DontDestroyOnLoad(gameObject);
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 0 -> 타이틀, 1-> 초반 2 -> 중간보스 3 -> 후반 4 -> 최종보스
    {
        nameScene = SceneManager.GetActiveScene().name;
        Debug.Log(nameScene);
        stageTier = nameScene[3] - '0';
        stageNo = nameScene[5] - '0';
        if (nameScene != "WorldScene" && nameScene != "TitleScene")
        {

            Debug.Log("LOG: STAGETIER : " + stageTier + "   STAGENO : " + stageNo);
           
            ChangeAudio(stageTier, stageNo);
        }
        else if(nameScene == "TitleScene")
        {
            audioSource.clip = audioClipArr[0];

            audioSource.Play();

        }
        else if (nameScene == "WorldScene" && currentAudio <= 1)
        {
            audioSource.clip = audioClipArr[1];
            if (currentAudio != 1)
            {
                audioSource.Play();

            }
            currentAudio = 1;
        }
        else if (nameScene == "WorldScene" && currentAudio == 3)
        {
            audioSource.clip = audioClipArr[3];
            if (currentAudio != 3)
            {
                audioSource.Play();

            }
            currentAudio = 3;
        }
    }

    void ChangeAudio(int tier, int num)
    {

        if(tier == 0)
        {
            audioSource.clip = audioClipArr[1];
            if (currentAudio != 1)
            {
                audioSource.Play();
            }
            currentAudio = 1;
            
        }
        else if (tier == 1)
        {
            audioSource.clip = audioClipArr[1];
            if (currentAudio != 1)
            {
                audioSource.Play();
            }
            currentAudio = 1;

        }
        else if (tier == 2)
        {
            audioSource.clip = audioClipArr[3];
            if (currentAudio != 3)
            {
                audioSource.Play();
            }
            currentAudio = 3;

        }
        else if (tier == 3)
        {
            audioSource.clip = audioClipArr[3];
            if (currentAudio != 3)
            {
                audioSource.Play();
            }
            currentAudio = 3;

        }
        else if(tier == 4)
        {
            if(num == 2 )
            {
                audioSource.clip = audioClipArr[2];
                if (currentAudio != 2)
                {
                    audioSource.Play();
                }
                currentAudio = 2;

            }
            else if(num == 3 )
            {
                audioSource.clip = audioClipArr[4];
                if (currentAudio != 4)
                {
                    audioSource.Play();
                }
                currentAudio = 4;

            }
        }


    }

}