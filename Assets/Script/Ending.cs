using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public void ReturnTitle()
    {
        //GameManager.Instance.ResetSave();
        //GameManager.Instance.Load();
        //PlayerState.Instance.Win();
        SceneManager.LoadScene("AdaptationScene");
    }
}
