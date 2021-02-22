using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public void PlaySound(int num)
    {
        AudioEffect.Instance.GetComponent<AudioEffect>().PlayAudio(num);
    }


}
