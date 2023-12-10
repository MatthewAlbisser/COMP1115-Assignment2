using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour       // Part2c: Attached to EndTrigger object.
{
    public Timer timer;                     // Part2c: Declares Timer script. (place in inspector)
    public PlayerMovement playerMovement;   // Part2c: Declares PlayerMovement script. (place in inspector)

    private bool endTrig = false;

    private void OnTriggerEnter2D(Collider2D other) // Part2c: If this trigger collides with...
    {
        if (other.CompareTag("Player"))             // Part2c: An object with the player tag...
        {
            endTrig = true;                         // Part2c: Set trigger bool to true.
        }
        if (endTrig)                                // Part2c: When trigger bool is set to true...
        {
            timer.StopTimer();              // Part2c: Activate StopTimer Method in Timer script.
            playerMovement.PlayerStop();    // Part2c: Activate PlayerStop Method in PlayerMovement script.

            // here, need to add an overlay for showing coins collected out of total and time left. //
        }
    }
}
