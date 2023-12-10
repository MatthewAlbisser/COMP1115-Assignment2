using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour     // Part1: Attached to player object.
{

    public float speed = 5f;    // Part1: Declares public speed variable.
    private Rigidbody2D rb;     // Part1: Declares private rigidbody variable.
    private bool canMove = true;    // Part2c: Bool for activating or deactivating player movement.

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;      // Part1: Freezes player rotation on start.
    }

    private void Update()
    {
        if (canMove)    // Part2c: Player control is active when canMove bool is set to true.
        {
            rb = GetComponent<Rigidbody2D>();                       // Part1: Initializes rigitbody component.
            rb.velocity = Vector2.zero;                             // Part1: Sets movement to zero when not moving.
            Vector2 dir = Vector2.zero;                             // Part1: Declare vector dir to hold direction variables.

            if (Input.GetKey(KeyCode.A))                            // Part1: Basic button directions via GetKey.
            {
                dir.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
            }


            if (Input.GetKey(KeyCode.LeftShift))                    // extra: When Lshift is pressed...
            {
                speed = 10f;                                        // extra: Speed is doubled.
            }
            else if (!Input.GetKey(KeyCode.RightShift))             // extra: When Lshift is not pressed...
            {
                speed = 5f;                                         // extra: Speed is reverted back.
            }
            dir.Normalize();                                        // extra: Scales speed to be consistant in diagnal directions.


            GetComponent<Rigidbody2D>().velocity = speed * dir;     // Part1: Sets speed of the Player rigidbody component.
        }
    }
    public void PlayerStop()        // Part2c: When method is activated...
    {
        canMove = false;            // Part2c: Deactivates player movement buttons.
        rb.velocity = Vector2.zero; // Part2c: Holds Player still, stops movement.
    }
}
