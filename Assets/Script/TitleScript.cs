using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string SceneToLoad;

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void LoadConfig()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
