using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart: MonoBehaviour       // Extra: Attached to StartTrigger object.
{
    public Timer timer;                     // Extra: Declares Timer script.
    private bool inRange;

    void Update()
    {
        if (inRange)            // If in range is activated...
        {
            if (Input.GetKeyDown(KeyCode.E))    // If pressing E...
            {
                timer.StartTimer();                     // Extra: Activate StartTimer Method in Timer script.
                gameObject.SetActive(false);            // Trigger attached to this script is deactivated.
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)  // When anything (player) is inside trigger area...
    {
        inRange = true;         // Inrange is activated.
    }

}
