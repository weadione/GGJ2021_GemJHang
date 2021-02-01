using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WScamera_script : MonoBehaviour
{

   // Start is called before the first frame update

   int speed = 10;

   void start(){

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
   void afterSceneStart(int stage){
      this.transform.localPosition = new Vector3(stage ,0,0);            

      return;
   }
}