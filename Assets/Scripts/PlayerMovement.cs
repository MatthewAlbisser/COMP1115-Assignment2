using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour     // Part1: Attached to player object.
{

    public float speed = 5f;    // Part1: Declares public speed variable.
    private Rigidbody2D rb;     // Part1: Declares private rigidbody variable.
    private bool canMove = true;    // Part2c: Bool for activating or deactivating player movement.
    public Animator animator;       // Part1: 
    SpriteRenderer spriteRenderer;  // Part1:
    public Sprite[] idle;           // Part1:

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;      // Part1: Freezes player rotation on start.
        spriteRenderer = GetComponent<SpriteRenderer>();        // Part1:

    }

    private void Update()
    {
        if (canMove)    // Part2c: Player control is active when canMove bool is set to true.
        {
            PlayerIdle();
            rb = GetComponent<Rigidbody2D>();                       // Part1: Initializes rigitbody component.
            rb.velocity = Vector2.zero;                             // Part1: Sets movement to zero when not moving.
            Vector2 dir = Vector2.zero;                             // Part1: Declare vector dir to hold direction variables.
            animator.SetBool("isMoving", false);                    // Part1:  
            animator.SetInteger("Directional", 4);

            if (Input.GetKey(KeyCode.A))                            // Part1: Basic button directions via GetKey.
            {
                dir.x = -1;
                animator.SetInteger("Directional", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Directional", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Directional", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Directional", 0);
            }


            if (Input.GetKey(KeyCode.LeftShift))                    // Extra: When Lshift is pressed...
            {
                speed = 10f;                                        // Extra: Speed is doubled.
                animator.SetBool("isSprinting", true);
            }
            else if (!Input.GetKey(KeyCode.RightShift))             // Extra: When Lshift is not pressed...
            {
                speed = 5f;                                         // Extra: Speed is reverted back.
                animator.SetBool("isSprinting", false);
            }
            dir.Normalize();                                        // Extra: Scales speed to be consistant in diagnal directions.
            animator.SetBool("isMoving", dir.magnitude > 0);        // Part1:
            GetComponent<Rigidbody2D>().velocity = speed * dir;     // Part1: Sets speed of the Player rigidbody component.
        }
    }
    public void PlayerStop()        // Part2c: When method is activated...
    {
        canMove = false;            // Part2c: Deactivates player movement buttons.
        rb.velocity = Vector2.zero; // Part2c: Holds Player still, stops movement.
    }
    void PlayerIdle()
    {
        if (Input.GetKey(KeyCode.A))                            // Part1: Idle sprite on button press.
        {
            spriteRenderer.sprite = idle[3];
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.sprite = idle[2];
        }

        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = idle[1];
        }
        else if (Input.GetKey(KeyCode.S))
        {
            spriteRenderer.sprite = idle[0];
        }
    }
}
