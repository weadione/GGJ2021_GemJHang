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

    private void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        initialize();
    }

    //체력, 뎀지, 근/원거리, 공속, 이속
    public void initialize()
    {
        enemyList[0].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 5f);   //뱀1,2,3
        enemyList[1].GetComponent<EnemyState>().changeState(120f, 20f, true, 1f, 6f);
        enemyList[2].GetComponent<EnemyState>().changeState(150f, 40f, true, 1f, 7f);
        enemyList[3].GetComponent<EnemyState>().changeState(70f, 10f, false, 1f, 5f);   //슬라임1,2
        enemyList[4].GetComponent<EnemyState>().changeState(100f, 20f, false, 0.8f, 7f);
        enemyList[5].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 5f);   //송충이
        enemyList[6].GetComponent<EnemyState>().changeState(100f, 10f, true, 1f, 7f);   //범퍼카1,2
        enemyList[7].GetComponent<EnemyState>().changeState(150f, 20f, true, 1f, 9f);
        enemyList[8].GetComponent<EnemyState>().changeState(120f, 40f, true, 1f, 4f);   //목마1,2
        enemyList[9].GetComponent<EnemyState>().changeState(150f, 60f, true, 1f, 5f);
        enemyList[10].GetComponent<EnemyState>().changeState(70f, 15f, false, 1f, 6f);  //쓰레기통1,2
        enemyList[11].GetComponent<EnemyState>().changeState(110f, 25f, false, 1f, 7f);
        enemyList[12].GetComponent<EnemyState>().changeState(250f, 40f, false, 1f, 6f);  //켄타우로스
        enemyList[13].GetComponent<EnemyState>().changeState(200f, 50f, true, 1f, 8f);  //전기톱1,2
        enemyList[14].GetComponent<EnemyState>().changeState(150f, 60f, true, 1f, 8f);
        enemyList[15].GetComponent<EnemyState>().changeState(300f, 30f, true, 1f, 7f);  //마르코(중간보스)







    }
}
