using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class NextScript : MonoBehaviour
{
    public void ScriptPass()
    {

        if (EventManager.Instance.GetComponent<EventManager>().selectStep == 0)
        {
            EventManager.Instance.GetComponent<EventManager>().scriptNum = 1;
        }
        else if (EventManager.Instance.GetComponent<EventManager>().selectStep == 1)
        {
         //   Debug.Log("스크립트를 넘깁니다.");
            EventManager.Instance.GetComponent<EventManager>().scriptNum = 2;
        }
        else if (EventManager.Instance.GetComponent<EventManager>().selectStep == 2)
        {
            EventManager.Instance.GetComponent<EventManager>().scriptNum = 3;
        }
        else if (EventManager.Instance.GetComponent<EventManager>().selectStep == 3)
        {
            Debug.Log("스크립트를 넘깁니다.");
            EventManager.Instance.GetComponent<EventManager>().scriptNum = 4;
        }
        else if (EventManager.Instance.GetComponent<EventManager>().selectStep == 4)
        {
            EventManager.Instance.GetComponent<EventManager>().scriptNum = 5;
        }
        else if (EventManager.Instance.GetComponent<EventManager>().selectStep == 5)
        {
            EventManager.Instance.GetComponent<EventManager>().scriptNum = 6;
        }
        
    }
}
