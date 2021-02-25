using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public EventManager EM;

    public void Select1()
    {
        Debug.Log("1번선택");
        EM.selectNum = 1;
        
    }

    public void Select2()
    {
        Debug.Log("2번선택");
        EM.selectNum = 2;
        Debug.Log(EM.selectNum);
    }

    public void Select3()
    {
        Debug.Log("3번선택");
        EM.selectNum = 3;
    }

    public void Select4()
    {
        Debug.Log("4번선택");
       EM.selectNum = 4;
    }



}
