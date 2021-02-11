using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public void Select1()
    {
        Debug.Log("1번선택");
        EventManager.Instance.GetComponent<EventManager>().selectNum = 1;
    }

    public void Select2()
    {
        Debug.Log("2번선택");
        EventManager.Instance.GetComponent<EventManager>().selectNum = 2;
    }

    public void Select3()
    {
        Debug.Log("3번선택");
        EventManager.Instance.GetComponent<EventManager>().selectNum = 3;
    }

    public void Select4()
    {
        Debug.Log("4번선택");
        EventManager.Instance.GetComponent<EventManager>().selectNum = 4;
    }



}
