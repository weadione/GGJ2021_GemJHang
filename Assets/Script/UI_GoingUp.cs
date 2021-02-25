using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_GoingUp : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    static   float fades = 0.0f;
    float time = 0;
    bool leavingWorld = false;
    bool onGoing = true;

    // Start is called before the first frame update
    void Start()
    {

        fade.transform.position = new Vector3(0,0,0);
    }

    void Update()
    {
        if(fades < 60.0f && !leavingWorld &&onGoing){
            fades +=1.0f;
            fade.transform.localPosition = new Vector3(0,fades,0);
        } else if(fades > -60.0f && leavingWorld&&onGoing){
            fades -=1.0f;
            fade.transform.localPosition = new Vector3(0,fades,0);
        } else if(fades >= 60.0f){
            leavingWorld = true;
            onGoing = false;
        }
        else if(fades <=-60.0f){
            leavingWorld = false;
            onGoing = false;
        }
    }


    void OnEnable(){
    
        fade.transform.position = new Vector3(0,0,0);
        SceneManager.sceneLoaded += OnSceneLoaded;       
         
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        fades = 0.0f;            
        onGoing = true;

    }
    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
