using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldmapScript : MonoBehaviour
{
    public int visitedStage = 0;    
    public int stageTier = 0;// 0: Forest, 1: Themepark, 2: Sewer, 3: Factory, 4: Lab aka Boss.
        
//    public bool isVisitedStage[5];
    public string SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void menuClick(){
        // Click한 버튼이 UI쪽 메뉴였을 경우 해당 함수를 불러온다. 
//        if(GameObject )

        SceneManager.LoadScene("Title");
    }

    public void nodeClick(){
        // Click한 부분이 스테이지(전투/이벤트 등)일 경우 씬 전환을 실행한다. 
        bool isCombat = true;
        if (isCombat)
            SceneToLoad = stageNameCalculate(visitedStage, stageTier);
//            SceneToLoad = stageNameCalculate(visitedStage, stageTier, isVisitedStage);
//        else 
//            SceneToLoad;

    }

//    public string stageNameCalculate(int visited, int Tier, bool visitedStage[5]){
    public string stageNameCalculate(int visited, int Tier){
        // Scene name을 자동으로 불러오게끔.
        // scene name List: 
        // BS_001, BS_002 ... BS_005, BS_011, BS_015, BS_021, ... BS_041, BS_042.

        string stagePrefab = "BS_"; 
        int stage = visited % 5;       // StageNumber
        string stageName = stagePrefab + 0 + Tier+ stage;

        return stageName;
    }

}
