using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement movement2D;

    void Start()
    {
        movement2D = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement2D.Move(x);
        movement2D.Jump();
        movement2D.Direction();
        if (Input.GetKeyDown(KeyCode.LeftShift))
            movement2D.Dash(x);

    }
}
