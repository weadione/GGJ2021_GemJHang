using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePosiitonScript : MonoBehaviour
{
    public int stageLevel;          // 노드의 정해진 스테이지 레벨.
    public int stem;

    public static int cur;          // 지나온, 현재 스테이지 레벨.
    public static bool [, ] isVisited = new bool [10,3];


    private GameObject battle, staying, chNode, eNode, arrow, arrow2;

    bool isVisitedThis;
    bool yetChanged = true;

    WorldmapScript call;
    void start(){
        call = GameObject.Find("Worldmap").GetComponent<WorldmapScript>();
        cur = call.currentStage; 
        DontDestroyOnLoad(gameObject);

        isVisitedThis = isVisited[stageLevel,stem];
    }

    void Update()
    {
        if(yetChanged){
            if(cur == 10)
                callEndingScene();
            yetChanged = false;
            GameObject cam = GameObject.Find("Main Camera").gameObject;
            //Debug.Log(cam.name);
            tryApsoluteXY();
        }

        if (isHit()&&!isVisited[stageLevel,stem]&& stageLevel == cur){
            isVisited[stageLevel,stem] = true;
            yetChanged = true;
            cur++;
            stageSelect();           
        }
    }
    void callEndingScene(){
        SceneManager.LoadScene("EndingScene");
    }
    void tryApsoluteXY(){
//        Debug.Log();


        battle = transform.GetChild(0).gameObject;      //  defaultZ: 0
        staying = transform.GetChild(1).gameObject;      //  defaultZ: -20
        chNode = transform.GetChild(2).gameObject;      //  defaultZ: -40
        eNode = transform.GetChild(3).gameObject;
        arrow = gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject;
        arrow2 = gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;

        
        Vector3 abBattle =  battle.transform.position;  
        Vector3 abStaying =  staying.transform.position;  
        Vector3 abChNode =  chNode.transform.position;  
         
        Vector3 arrowPos =  arrow.transform.position;   
        Vector3 arrow2Pos =  arrow2.transform.position; 
        


        if(cur == stageLevel){
            battle.transform.position = new Vector3(abBattle.x,abBattle.y,10);   // 보이게
            arrow.transform.position = new Vector3(arrowPos.x,arrowPos.y,10);   
            arrow2.transform.position = new Vector3(arrow2Pos.x,arrow2Pos.y,10);   
        }
        else if(cur == stageLevel+1 && isVisited[stageLevel,stem] == true){
            // show my icon

            battle.transform.position = new Vector3(abBattle.x,abBattle.y,-20);   // 안 보이게
            arrow.transform.position = new Vector3(arrowPos.x,arrowPos.y,10);  
            arrow2.transform.position = new Vector3(arrow2Pos.x,arrow2Pos.y, 10);  
            staying.transform.position = new Vector3(abStaying.x,abStaying.y,10);   // 보이게
            chNode.transform.position = new Vector3(abChNode.x,abChNode.y,-20); 
        }else if(cur == stageLevel+1 && isVisited[stageLevel,stem] == false){      // 다음방

            battle.transform.position = new Vector3(abBattle.x,abBattle.y,10);   // 보이게
            arrow.transform.position = new Vector3(arrowPos.x,arrowPos.y,10);   
            arrow2.transform.position = new Vector3(arrow2Pos.x,arrow2Pos.y,10);   
            staying.transform.position = new Vector3(abStaying.x,abStaying.y,-20);   
            chNode.transform.position = new Vector3(abChNode.x,abChNode.y,-20); 
            // do nothing
        }else if(cur > stageLevel && isVisited[stageLevel,stem] == true){       // 방문한 지난 방
            battle.transform.position = new Vector3(abBattle.x,abBattle.y,-20);   // 보이게            
            arrow.transform.position = new Vector3(arrowPos.x,arrowPos.y,10);   
            arrow2.transform.position = new Vector3(arrow2Pos.x,arrow2Pos.y,10);   
            staying.transform.position = new Vector3(abStaying.x,abStaying.y,-20);   
            chNode.transform.position = new Vector3(abChNode.x,abChNode.y,20); 
        }else if(cur > stageLevel && isVisited[stageLevel,stem] == false){      // 방문하지 않은 지난 방
            battle.transform.position = new Vector3(abBattle.x,abBattle.y,10);   // 보이게            
            arrow.transform.position = new Vector3(arrowPos.x,arrowPos.y,10);   
            arrow2.transform.position = new Vector3(arrow2Pos.x,arrow2Pos.y,10);   
            staying.transform.position = new Vector3(abStaying.x,abStaying.y,-20);   
            chNode.transform.position = new Vector3(abChNode.x,abChNode.y,-20); 
        }
    }

    void stageSelect(){            
        string NextScene = "";
        bool isFront;
        int bsn = Random.Range(0,8);
        if(cur!= 0 &&cur %5 == 0){
            NextScene = "BS_40"+(cur/5+1);
            SceneManager.LoadScene(NextScene);
            return;
        }

        if(cur < 6)
            isFront = true;
        else
            isFront = false;

        for (int i = 0; i < 3; i++)
        {
            PlayerState.Instance.GetComponent<PartsManager>().ChangeParts(i, Random.Range(0, 9));
        }

        if (isFront){
        switch(bsn){
            case 0:
                // NextScene = "BS_001";
                // break;
            case 1:
                NextScene = "BS_002";
                break;
            case 2:
                NextScene = "BS_003";
                break;
            case 3:
                NextScene = "BS_004";
                break;
            case 4:
                NextScene = "BS_005";
                break;
            case 5:
                NextScene = "BS_101";
                break;
            case 6:
                NextScene = "BS_102";
                break;
            case 7:
                NextScene = "BS_103";
                break;
        }
        }
        else {
            switch(bsn){
            case 0:
                NextScene = "BS_201";
                break;
            case 1:
                NextScene = "BS_202";
                break;
            case 2:
                NextScene = "BS_203";
                break;
            case 3:
                NextScene = "BS_204";
                break;
            case 4:
                NextScene = "BS_301";
                break;
            case 5:
                NextScene = "BS_302";
                break;
            case 6:
                NextScene = "BS_303";
                break;
            case 7:
                NextScene = "BS_304";
                break;
        }
        }
        SceneManager.LoadScene(NextScene);

   }
    bool isHit(){
         if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == this.transform){
                return true;
            }
            else{
               return false;
            }
        }
        return false;
    }
}

