using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public PartsManager PM;

    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                instance = FindObjectOfType<ItemManager>();
            }

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CP(int partsType,int partsNum)
    {
        PM.ChangeParts(partsType, partsNum);
    }


}
