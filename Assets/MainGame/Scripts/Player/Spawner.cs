using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PlayerState player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerState>();
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
