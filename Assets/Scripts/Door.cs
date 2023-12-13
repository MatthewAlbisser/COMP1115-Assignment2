using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool inRange;           // Bool for in range to interact.
    public Key key;                 // Declares Key script.

    void Update()
    {
        if (inRange)                                // If door is in range is activated...
        {
            if (key.hasKey)                         // If player has key...
            {
                if (Input.GetKeyDown(KeyCode.E))    // If player presses E...
                {
                    OpenDoor();                     // Activates OpenDoor method.
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)  // When anything (player) is inside trigger area...
    {
        inRange = true;         // Inrange is activated.
    }
    void OpenDoor()
    {
        gameObject.SetActive(false);    // Object attached to this script is deactivated.
    }
}