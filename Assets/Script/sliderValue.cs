using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderValue: MonoBehaviour
{
    Text valueText;
    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void valueUpdate(float value){
        valueText.text = Mathf.RoundToInt(value * 100)+"%";
    }
}
