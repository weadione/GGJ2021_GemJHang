using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyList;

    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                instance = FindObjectOfType<EnemyManager>();
            }

            // 싱글톤 오브젝트를 반환
            return instance;
        }
    }

    private int[] tmpParts;

    private void Awake()
    {

        initialize();
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    //체력, 뎀지, 근/원거리, 공속, 이속
    public void initialize()
    {
        enemyList[0].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 5f, new int[3] { 2, 0, 1});   //뱀1,2,3
        enemyList[1].GetComponent<EnemyState>().changeState(120f, 20f, true, 1f, 6f, new int[3] { 3, 0, 2 });
        enemyList[2].GetComponent<EnemyState>().changeState(150f, 40f, true, 1f, 7f, new int[3] { 4, 0, 3 });
        enemyList[3].GetComponent<EnemyState>().changeState(70f, 10f, false, 1f, 5f, new int[3] { 5, 2, 0 });   //슬라임1,2
        enemyList[4].GetComponent<EnemyState>().changeState(100f, 20f, false, 0.8f, 7f, new int[3] { 6, 3, 0 });
        enemyList[5].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 5f, new int[3] { 1, 1, 0 });   //송충이
        enemyList[6].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 7f, new int[3] { 7, 0, 4 });   //범퍼카1,2
        enemyList[7].GetComponent<EnemyState>().changeState(150f, 20f, true, 1f, 9f, new int[3] { 8, 9, 5 });
        enemyList[8].GetComponent<EnemyState>().changeState(120f, 40f, true, 1f, 4f, new int[3] { 0, 0, 6 });   //목마1,2
        enemyList[9].GetComponent<EnemyState>().changeState(150f, 60f, true, 1f, 5f, new int[3] { 0, 0, 7 });
        enemyList[10].GetComponent<EnemyState>().changeState(70f, 15f, false, 1f, 6f, new int[3] { 0, 4, 8 });  //쓰레기통1,2
        enemyList[11].GetComponent<EnemyState>().changeState(110f, 25f, false, 1f, 7f, new int[3] { 0, 5, 9 });
        enemyList[12].GetComponent<EnemyState>().changeState(250f, 40f, false, 1f, 6f, new int[3] { 0, 6, 0 });  //켄타우로스
        enemyList[13].GetComponent<EnemyState>().changeState(200f, 50f, true, 1f, 8f, new int[3] { 0, 7, 0 });  //전기톱1,2
        enemyList[14].GetComponent<EnemyState>().changeState(150f, 60f, true, 1f, 8f, new int[3] { 0, 8, 0 });
        enemyList[15].GetComponent<EnemyState>().changeState(300f, 30f, true, 1f, 7f, new int[3] { 0, 0, 0 });  //마르코(중간보스)
        enemyList[16].GetComponent<EnemyState>().changeState(1000f, 50f, true, 1f, 7f, new int[3] { 0, 0, 0 });  //최종보스
        enemyList[17].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 5f, new int[3] { 0, 0, 0 });  //잡몹클론







    }
}
