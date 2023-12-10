using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart: MonoBehaviour       // Part2c: Attached to EndTrigger object.
{
    public Timer timer;                     // Part2c: Declares Timer script.

    private void OnTriggerEnter2D(Collider2D other) // Part2c: If this trigger collides with...
    {
        if (other.CompareTag("Player"))             // Part2c: An object with the player tag...
        {
            timer.StartTimer();                     // Part2c: Activate StartTimer Method in Timer script.
        }
    }
}
