using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgCamScript : MonoBehaviour
{
    string nameScene;
    int stageTier = -1;
    int stageNo = -1;

    private GameObject camera;
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

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        nameScene = SceneManager.GetActiveScene().name;
        if(nameScene != "WorldScene" && nameScene != "Title"){
            stageTier = nameScene[3] - '0';
            stageNo = nameScene[5]- '0';
//            Debug.Log("LOG: STAGETIER : " + stageTier + "   STAGENO : " + stageNo);
            changeCameraPosition(stageTier, stageNo);
        }
    }

    void changeCameraPosition(int tier, int num){
        camera = transform.GetChild(0).gameObject;
        Debug.Log(camera.name);
        Vector3 abCam = camera.transform.position;
        float x = abCam.x;
        float y = abCam.y;
        float z = abCam.z + 10 * stageTier;
        if(tier == 4 && num == 2){
            Debug.Log("402");
            camera.transform.position = new Vector3(abCam.x, abCam.y,40);
            return;
        }

        if(tier == 4 && num == 3){
            Debug.Log("403");
            camera.transform.position = new Vector3(abCam.x, abCam.y,50);
            return;
        }
        camera.transform.position = new Vector3(abCam.x, abCam.y, 10*stageTier-3);
        Debug.Log(camera.transform.position);


    }

}


