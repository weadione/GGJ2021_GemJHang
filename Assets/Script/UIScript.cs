using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private static GameObject instance;
    public static GameObject Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
               instance = GameObject.FindWithTag("DontDestroy");
            }

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this.gameObject;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
