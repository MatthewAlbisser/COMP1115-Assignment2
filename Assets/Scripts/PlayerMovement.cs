using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour     // Attached to player object.
{

    public float speed = 5f;                    // Part1: Declares public speed variable.
    private Rigidbody2D rb;                     // Part1: Declares private rigidbody variable.

    public bool canMove = true;                 // Part2c: Bool for activating or deactivating player movement.
    public Animator animator;                   // Part1: Declares the player animator.

    public SpriteRenderer spriteRenderer;       // Part1: Declares the player sprite componant.
    public Sprite[] idle = new Sprite[4];       // Part1: Array to hold Idle sprites.
    public Vector2 lastDir = Vector2.zero;      // Part1: Holds last movement direction.
    public bool isMoving = false;               // Part1: creates bool for activating or deactivating player sprites or animations, starts at false.

    private float animSprint = 2.0f;            // Part1: Set float for animation running speed.
    private float animWalk = 1f;                // Part1: Set float for animation walking speed.

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;      // Part1: Freezes player rotation on start.
        spriteRenderer = GetComponent<SpriteRenderer>();        // Part1: Initalizes the sprite renderer.

    }

    private void Update()
    {
        if (canMove)    // Part2c: Player control is active when canMove bool is set to true.
        {
            rb = GetComponent<Rigidbody2D>();           // Part1: Initializes rigitbody component.
            rb.velocity = Vector2.zero;                 // Part1: Sets movement to zero when not moving.
            Vector2 dir = Vector2.zero;                 // Part1: Declare vector dir to hold direction variables.

            animator.SetBool("Moving", false);          // Part1: When not moving, sets animation bool to false. 
            isMoving = false;                           // Part1: When not moving, sets ismoving bool to false.

            if (Input.GetKey(KeyCode.A))                // Part1: Basic button directions via GetKey.
            {
                dir.x = -1;                             // Part1: Force direction of movement.
                lastDir = Vector2.left;                 // Part1: Saved last direction of movement.
                animator.SetInteger("Directional", 3);  // Part1: Set animation for direction of movement.
                isMoving = true;                        // Part1: Set isMoving to true, holding back idle sprites and letting animations take over.
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

            if (Input.GetKey(KeyCode.LeftShift))            // Part1: When Lshift is pressed...
            {
                speed = 10f;                                                            // Part1: Speed is doubled.                               
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);  // Part1: Gets the current animation state.
                animator.SetFloat("SprintAnim", animSprint);                            // Part1: Changes animation speed with declared float.
            }
            else if (!Input.GetKey(KeyCode.LeftShift))      // Part1: When Lshift is not pressed...
            {
                speed = 5f;                                                             // Part1: Speed is reverted back.
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);  // Part1: Gets the current animation state.
                animator.SetFloat("SprintAnim", animWalk);                              // Part1: Changes animation speed with declared float.
            }
            
            dir.Normalize();                                    // Part1: Changes speed from direction to vector value. Keeps consistant in diagnal directions.
            animator.SetBool("Moving", dir.magnitude > 0);      // Part1: Moving animations play when speed is over 0.
            GetComponent<Rigidbody2D>().velocity = speed * dir; // Part1: Sets speed of the Player rigidbody component.
        }
    }

    void LateUpdate()       // Part1: Void for updates after the other goes first.
    {
        if (!isMoving)      // Part1: isMoving is false when player isnt moving.
        {
            if (lastDir == Vector2.left)            // Part1: if Players last direction was Left...
            {
                spriteRenderer.sprite = idle[3];    // Part1: Player sprite is changed to one from the array.
                spriteRenderer.flipX = true;        // Part1: Sprite is flipped on the X axis. (Dont have a left facing sprite)
            }                                       // Part1: Others are set to false because FlipX saves over to the next. 
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
    }
    public void PlayerStop()        // Part2c: When method is activated...
    {
        canMove = false;            // Part2c: Deactivates player movement buttons.
        rb.velocity = Vector2.zero; // Part2c: Holds Player still, stops movement.
    }
}
