using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class NextScript : MonoBehaviour
{
    public EventManager EM;


    public void ScriptPass()
    {

        if (EM.selectStep == 0)
        {
            EM.scriptNum = 1;
        }
        else if (EM.selectStep == 1)
        {
         //   Debug.Log("스크립트를 넘깁니다.");
            EM.scriptNum = 2;
            Debug.Log(EM.scriptNum);
        }
        else if (EM.selectStep == 2)
        {
            EM.scriptNum = 3;
        }
        else if (EM.selectStep == 3)
        {
            Debug.Log("스크립트를 넘깁니다.");
            EM.scriptNum = 4;
        }
        else if (EM.selectStep == 4)
        {
            EM.scriptNum = 5;
        }
        else if (EM.selectStep == 5)
        {
            EM.scriptNum = 6;
        }
        else if (EM.selectStep == 6)
        {
            EM.scriptNum = 7;
        }

    }
}
