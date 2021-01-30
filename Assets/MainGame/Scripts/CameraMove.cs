using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public PlayerState player;

    private void Start()
    {
        player = FindObjectOfType<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
