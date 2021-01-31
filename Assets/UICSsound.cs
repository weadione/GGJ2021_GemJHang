using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICSsound : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource audio;

    private float backVol = 1f;

    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }
    public void SoundSlider(){
        audio.volume = backVolume.value;

        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol",backVol);
    }
    public void SoundOnOff(bool isMuted){
        if(isMuted == true){
            // mute
            backVolume.value = 0;
            audio.volume = 0;
        }

    }
}
