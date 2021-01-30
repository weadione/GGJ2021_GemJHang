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
        isVisitedThis = isVisited[stageLevel,stem];
    }

    // Update is called once per frame
    void Update()
    {
        if(yetChanged){
            yetChanged = false;
            Debug.Log("2nd condition " + (cur == stageLevel+1 && isVisited[stageLevel,stem] == true));
            Debug.Log("cur : " + cur +"   isVisited: " + isVisited[stageLevel,stem]);
            tryApsoluteXY();
        }

        if (isHit()&&!isVisited[stageLevel,stem]&& stageLevel == cur){
            isVisited[stageLevel,stem] = true;
            yetChanged = true;
            Debug.Log("currentStage: " + cur);
            cur++;
            stageSelect();           
        }
    }
    void tryApsoluteXY(){
        battle = transform.GetChild(0).gameObject;      //  defaultZ: 0
        staying = transform.GetChild(1).gameObject;      //  defaultZ: -20
        chNode = transform.GetChild(2).gameObject;      //  defaultZ: -40
        eNode = transform.GetChild(3).gameObject;
        arrow = gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject;
        arrow2 = gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;

        
        Vector3 tempPos =  battle.transform.position;   
        Vector3 arrowPos =  arrow.transform.position;   
        Vector3 arrow2Pos =  arrow2.transform.position; 
        Debug.Log(tempPos); 
        Debug.Log(arrowPos); 
        Debug.Log(arrow2Pos); 
                 
        if(cur == stageLevel){
            Debug.Log("001 : show battle," );
            battle.transform.localPosition = new Vector3(0,0,50);   // 보이게
            arrow.transform.localPosition = new Vector3(0,0,50);   // 보이게
            arrow2.transform.localPosition = new Vector3(0,0,50);   // 보이게
        }
        else if(cur == stageLevel+1 && isVisited[stageLevel,stem] == true){
            // show my icon
            Debug.Log("002 : show staying" + staying.transform.localPosition);
            staying.transform.localPosition = new Vector3(0,0,50);
            battle.transform.localPosition = new Vector3(0,0,-50);
            arrow.transform.localPosition = new Vector3(0,0,-50);
            arrow2.transform.localPosition = new Vector3(0,0,-50);

        }else if(cur == stageLevel+1 && isVisited[stageLevel,stem] == false){
            battle.transform.localPosition = new Vector3(0,0,50);
            arrow.transform.localPosition = new Vector3(0,0,50); 
            arrow2.transform.localPosition = new Vector3(0,0,50);
            // do nothing
        }else if(cur > stageLevel && isVisited[stageLevel,stem] == true){
            staying.transform.localPosition = new Vector3(0,0,-50);
            chNode.transform.localPosition = new Vector3(0,0,50);
        }
    }
    void newnewOnHit(){            
        battle = transform.GetChild(0).gameObject;      //  defaultZ: 0
        staying = transform.GetChild(1).gameObject;      //  defaultZ: -20
        chNode = transform.GetChild(2).gameObject;      //  defaultZ: -40
        eNode = transform.GetChild(3).gameObject;
        arrow = gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject;
        arrow2 = gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;

        
        if(cur == stageLevel){
            Debug.Log("001 : show battle," );
            battle.transform.localPosition = new Vector3(0,0,50);   // 보이게
            arrow.transform.localPosition = new Vector3(0,0,50);   // 보이게
            arrow2.transform.localPosition = new Vector3(0,0,50);   // 보이게
        }
        else if(cur == stageLevel+1 && isVisited[stageLevel,stem] == true){
            // show my icon
            staying.transform.localPosition = new Vector3(0,0,50);
            battle.transform.localPosition = new Vector3(0,0,-50);
            arrow.transform.localPosition = new Vector3(0,0,-50);
            arrow2.transform.localPosition = new Vector3(0,0,-50);

        }else if(cur == stageLevel+1 && isVisited[stageLevel,stem] == false){
            battle.transform.localPosition = new Vector3(0,0,50);
            arrow.transform.localPosition = new Vector3(0,0,50); 
            arrow2.transform.localPosition = new Vector3(0,0,50);
            // do nothing
        }else if(cur > stageLevel && isVisited[stageLevel,stem] == true){
            staying.transform.localPosition = new Vector3(0,0,-50);
            chNode.transform.localPosition = new Vector3(0,0,50);
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



        if(isFront){
        switch(bsn){
            case 0:
                NextScene = "BS_001";
                break;
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
    // void newOnHit(int hitt){
    //     obj1 = transform.GetChild(hitt).gameObject;//
    //     if(hitt>0)
    //         obj2 = transform.GetChild(hitt-1).gameObject;//
    //     obj1.transform.localPosition = new Vector3(0,0,+50*hitt);
    //     if(hitt>0){
    //         obj2.transform.localPosition = new Vector3(0,0,-150*hitt);
    //     }
    // }
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

