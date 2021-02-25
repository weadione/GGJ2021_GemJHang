using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffect : MonoBehaviour
{
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

    public AudioSource effectSource;
    public AudioClip[] audioEffect;


    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this.gameObject;
        DontDestroyOnLoad(gameObject);
        effectSource = GetComponent<AudioSource>();


    }

    public void PlayAudio(int num) // 1. 타격, 2. 피격, 3. 점프, 4. 터치음
    {
        if (num == 1)
        {
            Debug.Log("AudioEffect: PlayAudio 1");
            effectSource.clip = audioEffect[0];

        }
        else if (num == 2)
        {
            Debug.Log("AudioEffect: PlayAudio 2");
            effectSource.clip = audioEffect[1];


        }
        else if (num == 3)
        {
            Debug.Log("AudioEffect: PlayAudio 3");
            effectSource.clip = audioEffect[2];
        }
        else if (num == 4)
        {
            Debug.Log("AudioEffect: PlayAudio 4");
            effectSource.clip = audioEffect[3];

        }
        else
        {   
            Debug.Log("ERROR");
        }
        effectSource.Play();

    }




}
