using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyList;

    private void Start()
    {
        initialize();
    }

    public void initialize()
    {
        enemyList[0].GetComponent<EnemyState>().changeState(10f, 10f, true, 1f, 5f);
        
    }
}
