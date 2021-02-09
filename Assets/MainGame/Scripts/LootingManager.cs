using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootingManager : MonoBehaviour
{
    public int[] tmp;
    bool sel;

    private void Start()
    {
        tmp = new int[4];
        sel = false;

    }
    private void Update()
    {
        if(sel == true && Input.GetKeyDown(KeyCode.H))
        {
            sel = false;
            tmp[3] = 1;
        }
        if (sel == true && Input.GetKeyDown(KeyCode.J))
        {
            sel = false;
            tmp[3] = 2;
        }
        if (sel == true && Input.GetKeyDown(KeyCode.K))
        {
            sel = false;
            tmp[3] = 3;
        }


    }


    public void Select(int[] loot)
    {
        sel = true;
        tmp[0] = loot[0];
        tmp[1] = loot[1];
        tmp[2] = loot[2];
        Debug.Log("셀렉트 실행");
    }

    public int[] change()
    {

        return tmp;
    }
}
