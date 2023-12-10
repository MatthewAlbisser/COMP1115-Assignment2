using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;                                 // Part1: Declares public speed variable.
    private Rigidbody2D rb;                      // Part1: Declares private rigidbody variable.
    void Start()
    { 
        GetComponent<Rigidbody2D>().freezeRotation = true;            // Part1: Freezes player rotation on start.
    }

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();                       // Part1: Initializes rigitbody component.
        rb.velocity = Vector2.zero;                             // Part1: Sets movement to zero when not moving.
        Vector2 dir = Vector2.zero;                             // Part1: Declare vector dir to hold direction variables.

        if (Input.GetKey(KeyCode.A))                            // Part1: Button Directions via GetKey.
        {
            dir.x = -1;
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                dir.x = -3;
            }
        }
        else if (Input.GetKey(KeyCode.D))                       // Part1: "A or D".
        {
            dir.x = 1;
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                dir.x = 3;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                dir.y = 3;
            }
        }
        else if (Input.GetKey(KeyCode.S))                       // Part1: "W or S".
        {
            dir.y = -1;
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
            {
                dir.y = -3;
            }
        }

        dir.Normalize();                                        // Part1: Scales speed to be consistant in diagnal directions.
        GetComponent<Rigidbody2D>().velocity = speed * dir;     // Part1: Sets speed of the Player rigidbody component.
    }
}
