using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool inRange;
    public Key key;

    void Update()
    {
        if (inRange)                                // If in range is activated...
        {
            if (key.hasKey)                         // If has key...
            {
                if (Input.GetKeyDown(KeyCode.E))    // If pressing E...
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