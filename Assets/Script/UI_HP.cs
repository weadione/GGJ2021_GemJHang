using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHPbar();
    }
    public void PlayerHPbar(){
        float HP =56;
        transform.GetChild(0).gameObject.GetComponent<image>.fillAmount = HP/100f;
        transform.GetChild(1).gameObject.text = string.Format("HP {0}/100", HP);
    }
}
