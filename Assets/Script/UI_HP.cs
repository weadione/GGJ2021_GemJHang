using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    float PHP, PHPMAX, HHP, HHPMAX;
    // Start is called before the first frame update
    void Start()
    {
//        Hpbar = hpBar.transform.
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPbar();
    }
    public void PlayerHPbar(){
         
        PHP =PlayerState.Instance.health;
        PHPMAX = 100f;

        HHP =PlayerState.Instance.headPartsHealth;
        HHPMAX =PlayerState.Instance.GetComponent<PartsManager>().headParts[PlayerState.Instance.partsNum[0]].partsHealth;

        transform.GetChild(0).GetComponent<Image>().fillAmount = PHP/PHPMAX;
        transform.GetChild(1).GetComponent<Text>().text = string.Format("HP "+ PHP +"/" + PHPMAX);
        transform.GetChild(2).GetChild(0).GetComponent<Image>().fillAmount = HHP/HHPMAX;
        transform.GetChild(2).GetChild(1).GetComponent<Text>().text = string.Format("HHP "+ HHP +"/" + HHPMAX);
    }
}
