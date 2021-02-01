using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldmapScript : MonoBehaviour
{
    public int currentStage = 0;
    

    void Start()
    {
        
    }

    void Update()
    {
        
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
