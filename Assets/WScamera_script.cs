using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WScamera_script : MonoBehaviour
{

    // Start is called before the first frame update

    int speed = 10;
    void Update()
    {        
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
        if(this.transform.position.x < 33 || xMove < 0)
            this.transform.Translate(new Vector3(xMove, 0, 0));  //이동
        

        
        // if(transform.position.x >-100) transform.position.x =-100;
        // if(transform.position.y < 100) transform.position.y =100;
        // if(transform.position.y >-100) transform.position.y =-100;
    }

}