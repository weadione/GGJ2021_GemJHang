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

    public void LoadConfig()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
