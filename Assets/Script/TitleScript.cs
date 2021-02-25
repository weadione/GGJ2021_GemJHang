using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string SceneToLoad;
    string SceneTitle = "WorldScene";
    static bool isFirst = true;


    public void LoadGame()
    {
        if(isFirst == true){
            SceneTitle = "IntroScene";
            isFirst = false;
        }
//        AudioEffect.Instance.GetComponent<AudioEffect>().PlayAudio(4);
        SceneManager.LoadScene(SceneTitle);
    }

    public void LoadOption()
    {
        // BGM 크기 조절, 타이틀 화면으로 
//        AudioEffect.Instance.GetComponent<AudioEffect>().PlayAudio(4);
        SceneManager.LoadScene(SceneToLoad);
    }
    public void LoadExit(){

//        AudioEffect.Instance.GetComponent<AudioEffect>().PlayAudio(4);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit(); // 어플리케이션 종료
    #endif
    }
    

}
