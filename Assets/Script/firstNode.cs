using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstNode : MonoBehaviour
{

    public static int curFirst = 0;          // 지나온, 현재 스테이지 레벨.


    private GameObject battle, staying, chNode, eNode, arrow, arrow2;

    bool yetChanged = true;

    WorldmapScript call;
    void start(){

    }

    void Update()
    {
        if(yetChanged){
            yetChanged = false;
            tryApsoluteXY();
            curFirst = 1;
        }
    }
    void tryApsoluteXY(){
//        Debug.Log();


        battle = transform.GetChild(0).gameObject;      //  defaultZ: 0
        staying = transform.GetChild(1).gameObject;      //  defaultZ: -20
        chNode = transform.GetChild(2).gameObject;      //  defaultZ: -40

        
        Vector3 abBattle =  battle.transform.position;  
        Vector3 abStaying =  staying.transform.position;  
        Vector3 abChNode =  chNode.transform.position;  
                 
         if(curFirst == 0){
            // show my icon
            battle.transform.position = new Vector3(abBattle.x,abBattle.y,-20);   // 안 보이게
            staying.transform.position = new Vector3(abStaying.x,abStaying.y,10);   // 보이게
            chNode.transform.position = new Vector3(abChNode.x,abChNode.y,-20); 
        }else if(curFirst != 0){       // 방문한 지난 방
            battle.transform.position = new Vector3(abBattle.x,abBattle.y,-20);   // 보이게        
            staying.transform.position = new Vector3(abStaying.x,abStaying.y,-20);   
            chNode.transform.position = new Vector3(abChNode.x,abChNode.y,20); 
        }
    }


}

