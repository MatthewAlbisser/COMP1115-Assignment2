using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart: MonoBehaviour       // Attached to StartTrigger object.
{
    public Timer timer;
    private bool inRange;

    void Update()
    {
        if (inRange)            // If in range is activated...
        {
            if (Input.GetKeyDown(KeyCode.E))        // If pressing E...
            {
                timer.StartTimer();                     // Activate StartTimer Method in Timer script.
                gameObject.SetActive(false);            // Green door thats attached to this script is deleted.
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)  // When anything (player) is inside trigger area...
    {
        inRange = true;     // Inrange is activated.
    }

}
