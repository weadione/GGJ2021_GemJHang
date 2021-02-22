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



    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        
        currentAudio = -1;
        DontDestroyOnLoad(gameObject);
        audioSource.volume = 0.5f;
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) // 0 -> 타이틀, 1-> 초반 2 -> 중간보스 3 -> 후반 4 -> 최종보스
    {
        nameScene = SceneManager.GetActiveScene().name;
        Debug.Log("Debug On AudioManager:OnSceneLoaded" + nameScene);
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
            audioSource.volume = 0.1f;
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
            audioSource.volume = 0.1f;
            if (currentAudio != 3)
            {
                audioSource.Play();
            }
            currentAudio = 3;

        }
        else if (tier == 3)
        {
            audioSource.clip = audioClipArr[3];
            audioSource.volume = 0.1f;
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
                audioSource.volume = 0.1f;
                if (currentAudio != 2)
                {
                    audioSource.Play();
                }
                currentAudio = 2;

            }
            else if(num == 3 )
            {
                audioSource.clip = audioClipArr[4];
                audioSource.volume = 0.07f;
                if (currentAudio != 4)
                {
                    audioSource.Play();
                }
                currentAudio = 4;

            }
        }


    }

    




}