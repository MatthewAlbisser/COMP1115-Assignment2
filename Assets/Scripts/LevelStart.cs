using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart: MonoBehaviour       // Extra: Attached to StartTrigger object.
{
    public Timer timer;                     // Extra: Declares Timer script.

    void OnTriggerEnter2D(Collider2D other) // Extra: If this trigger collides with...
    {
        if (other.CompareTag("Player"))             // Extra: An object with the player tag...
        {
            timer.StartTimer();                     // Extra: Activate StartTimer Method in Timer script.
            //Destroy(this);
            
        }
    }

}
