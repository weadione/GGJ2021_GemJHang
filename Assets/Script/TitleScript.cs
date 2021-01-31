using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string SceneToLoad;
    string SceneTitle = "WS";

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneTitle);
    }

    public void LoadOption()
    {   
        // BGM 크기 조절, 타이틀 화면으로 
        SceneManager.LoadScene(SceneToLoad);
    }
    public void LoadExit(){
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit() // 어플리케이션 종료
    #endif
    }
    

}
