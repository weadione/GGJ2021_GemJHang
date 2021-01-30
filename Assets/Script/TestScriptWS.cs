using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;



public class TestScriptWS : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("누름");
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("뗌");
    }

}