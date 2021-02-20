using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayAudioEffect(int num) // 1. 근거리 공격, 2. 원거리 공격, 3. 점프, 4. 피격
    {
        if (num == 1)
        {
            audioSource.PlayOneShot(audioClip[0]);
            Debug.Log("근거리공격소리");
        }
        else if (num == 2)
        {
            audioSource.PlayOneShot(audioClip[1]);
            audioSource.clip = audioClip[1];


        }
        else if(num == 3)
        {
            audioSource.PlayOneShot(audioClip[2]);
            audioSource.clip = audioClip[2];

        }
        else if(num == 4)
        {
            audioSource.PlayOneShot(audioClip[3]);
            audioSource.clip = audioClip[3];

        }
        


    }

}
