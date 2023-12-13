using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour     // Part1: Attached to player object.
{

    public float speed = 5f;                    // Part1: Declares public speed variable.
    private Rigidbody2D rb;                     // Part1: Declares private rigidbody variable.

    public bool canMove = true;                // Part2c: Bool for activating or deactivating player movement.
    public Animator animator;                   // Part1: Declares the player animator.

    public SpriteRenderer spriteRenderer;      // Part1: Declares the player sprite componant.
    public Sprite[] idle = new Sprite[4];       // Part1: Array to hold Idle sprites.
    public Vector2 lastDir = Vector2.zero;      // Part1: Holds last movement direction
    public bool isMoving = false;

    private float animSprint = 2.0f;            // Extra: Set float for animation running speed.
    private float animWalk = 1f;                // Extra: Set float for animation walking speed.

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;      // Part1: Freezes player rotation on start.
        spriteRenderer = GetComponent<SpriteRenderer>();        // Part1: Initalizes the sprite renderer.

    }

    private void Update()
    {
        if (canMove)    // Part2c: Player control is active when canMove bool is set to true.
        {
            rb = GetComponent<Rigidbody2D>();                       // Part1: Initializes rigitbody component.
            rb.velocity = Vector2.zero;                             // Part1: Sets movement to zero when not moving.
            Vector2 dir = Vector2.zero;                             // Part1: Declare vector dir to hold direction variables.

            animator.SetBool("isMoving", false);                    // Part1:  
            animator.SetInteger("Directional", 4);
            isMoving = false;

            if (Input.GetKey(KeyCode.A))                            // Part1: Basic button directions via GetKey.
            {
                dir.x = -1;
                lastDir = Vector2.left;
                animator.SetInteger("Directional", 3);
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                lastDir = Vector2.right;
                animator.SetInteger("Directional", 2);
                isMoving = true;
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                lastDir = Vector2.up;
                animator.SetInteger("Directional", 1);
                isMoving = true;

            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                lastDir = Vector2.down;
                animator.SetInteger("Directional", 0);
                isMoving = true;
            }
            if (!isMoving)
            {
                PlayerIdle();
            }
            
            if (Input.GetKey(KeyCode.LeftShift))            // Extra: When Lshift is pressed...
            {
                speed = 10f;                                                            // Extra: Speed is doubled.                               
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);  // Extra: Gets the current animation state
                animator.SetFloat("SprintAnim", animSprint);                            // Extra: Multiplies animation speed with declared float.
            }
            else if (!Input.GetKey(KeyCode.LeftShift))      // Extra: When Lshift is not pressed...
            {
                speed = 5f;                                                             // Extra: Speed is reverted back.
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);  // Extra:
                animator.SetFloat("SprintAnim", animWalk);                              // Extra: Multiplies animation speed with declared float.
            }
            
            dir.Normalize();                                        // Part1: Scales speed to be consistant in diagnal directions.
            animator.SetBool("isMoving", dir.magnitude > 0);        // Part1: Moving animations play when speed is over 0.
            GetComponent<Rigidbody2D>().velocity = speed * dir;     // Part1: Sets speed of the Player rigidbody component.
        }
    }

    void LateUpdate()
    {
        if (!isMoving)
        {
            PlayerIdle();
        }
    }

    void PlayerIdle()
    {
        if (lastDir == Vector2.left)
        {
            spriteRenderer.sprite = idle[3];
            spriteRenderer.flipX = true;
        }
        else if (lastDir == Vector2.right)
        {
            spriteRenderer.sprite = idle[2];
            spriteRenderer.flipX = false;
        }
        else if (lastDir == Vector2.up)
        {
            spriteRenderer.sprite = idle[1];
            spriteRenderer.flipX = false;
        }
        else if (lastDir == Vector2.down)
        {
            spriteRenderer.sprite = idle[0];
            spriteRenderer.flipX = false;
        }
    }
    public void PlayerStop()        // Part2c: When method is activated...
    {
        canMove = false;            // Part2c: Deactivates player movement buttons.
        rb.velocity = Vector2.zero; // Part2c: Holds Player still, stops movement.
    }
}
