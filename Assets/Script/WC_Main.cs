using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WC_Main : MonoBehaviour
{

   // Start is called before the first frame update

   int speed = 10; 
   int currentStageCamera = 0;

   void Start(){

   }
   void Update()
   {


      float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
      
      if (this.transform.position.x >= 0 && this.transform.position.x <= 36)
        {
         this.transform.Translate(new Vector3(xMove, 0, 0));  //이동
      }
      else if(this.transform.position.x < 0)
        {
         this.transform.position = new Vector3(0, 0, -10);
        }
      else if (this.transform.position.x > 36)
      {
         this.transform.position = new Vector3(36, 0, -10);
      }
   }

   void OnEnable(){
      SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
       currentStageCamera = ChangePosiitonScript.cur;
//       Debug.Log("LOG : currentStageCamera = " + currentStageCamera);
      if(currentStageCamera <=1)
         return;
      if(currentStageCamera <4)
         this.transform.Translate((currentStageCamera-1)*3+1 , 0, 0);
      else
         this.transform.Translate((currentStageCamera)*4+2 , 0, 0);


    }
   void OnDisable(){
      SceneManager.sceneLoaded -= OnSceneLoaded;
    }

   public void setCurrentStage(int a){
      currentStageCamera = a;
   }
   public int getCurrentStage(){
      return currentStageCamera;
   }
   void afterSceneStart(int stage){
      this.transform.localPosition = new Vector3(stage ,0,0);            

      return;
   }
}