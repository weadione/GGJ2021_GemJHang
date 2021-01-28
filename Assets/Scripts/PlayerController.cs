using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement movement2D;

    //Horizontal => a, <-의 경우 -1이고, d, ->의 경우 +1임 Vertical은 위 아래(w/s) 
    // Start is called before the first frame update

    void Start()
    {
        movement2D = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.Move(x);
        movement2D.Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift))
            movement2D.Dash(x);

    }
}
