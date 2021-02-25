using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MiddleBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calledMiddle(){
        ChangePosiitonScript.isMiddleBeaten = true;
        SceneManager.LoadScene("WorldScene");
    }

}
