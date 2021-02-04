using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageExit : MonoBehaviour
{

    public void stageExit()
    {
        SceneManager.LoadScene("WorldScene");
        gameObject.SetActive(false);

    }
}
