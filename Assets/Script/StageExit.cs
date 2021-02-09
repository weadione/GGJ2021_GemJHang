using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageExit : MonoBehaviour
{
    public void stageExit()
    {
        GameManager.Instance.Save();
        SceneManager.LoadScene("WorldScene");
        gameObject.SetActive(false);

    }
}
