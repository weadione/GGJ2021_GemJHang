using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsManager : MonoBehaviour
{
    public GameObject[] armList;
    public GameObject[] legList;
    public GameObject[] headList;

    public Parts[] armParts;
    public Parts[] legParts;
    public Parts[] headParts;


    // Start is called before the first frame update
    void Start()
    {
        initalize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armParts[0].mainObject.SetActive(true);
            armParts[1].mainObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armParts[1].mainObject.SetActive(true);
            armParts[0].mainObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            legParts[0].mainObject.SetActive(true);
            legParts[1].mainObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            legParts[1].mainObject.SetActive(true);
            legParts[0].mainObject.SetActive(false);
        }

    }

    public void initalize()
    {
        armParts = new Parts[2];
        legParts = new Parts[2];
        headParts = new Parts[1];

        armParts[0] = new Parts(0f, 10f, true, 1f, 0f, "bug");
        armParts[1] = new Parts(0f, 20f, true, 1f, 0f, "elephant");


        legParts[0] = new Parts(0f, 0f, true, 0f, 10f, "snake");
        legParts[1] = new Parts(0f, 0f, true, 0f, 15f, "horse");

        headParts[0] = new Parts(50f, 0f, true, 0f, 0f, "bug");

        for (int i = 0; i < armList.Length; i++)
            armParts[i].mainObject = armList[i];

        for (int i = 0; i < legList.Length; i++)
            legParts[i].mainObject = legList[i];

        for (int i = 0; i < headList.Length; i++)
            headParts[i].mainObject = headList[i];
    }

}
