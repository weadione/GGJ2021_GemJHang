using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldmapScript : MonoBehaviour
{
    public int currentStage = 0;
    public static int [, ] eventNode = new int [10 ,3]; 
    public static bool calledOnlyOnce = false;    

    void Start()
    {
        if(calledOnlyOnce == false){
            randomizeEventsNode();
            calledOnlyOnce = true;
        }
    }

    void Update()
    {
        
    }

    public void randomizeEventsNode(){
        Debug.Log("randomizeEventsNode called ");
        int tmpRandom;
        for(int i=0;i<10;i++){
            for (int j=0;j<3;j++)
                eventNode[i,j] = Random.Range(0,100);
        }
    }
    public void setEvent(){

    }
    public void setCurrentStage(int a){
        currentStage = a;
    }
    public void LoadMap()
    {
        SceneManager.LoadScene("WorldScene");
    }
    public void LoadTitle(){
        SceneManager.LoadScene("TitleScene");
    }
    public void LoadEquip(){
        Debug.Log("Window Equip");
//        SceneManager.LoadScene("");
    }
    public void LoadVolume(){
        Debug.Log("On and Off Volume");
    }
    public void LoadOption(){
        Debug.Log("Window Option");
    }
    public void LoadSurrender(){
        Debug.Log("Surrendered");
    }
}
