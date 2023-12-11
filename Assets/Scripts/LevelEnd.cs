using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour       // Part2c: Attached to EndTrigger object.
{
    public Timer timer;                     // Part2c: Declares Timer script.
    public PlayerMovement playerMovement;   // Part2c: Declares PlayerMovement script.
    public GameObject HudDisplay;           // Part3: Declares Hud canvas objects.
    public GameObject EndDisplay;           // Part3: Declares end display canvas objects.
    public GameObject FailDisplay;          // Part3: Declares fail display text object.

    private void OnTriggerEnter2D(Collider2D other) // Part2c: If this trigger collides with...
    {
    if (other.CompareTag("Player"))    // Part2c: An object with the player tag...
        {
            timer.StopTimer();              // Part2c: Activate StopTimer Method in Timer script.
            playerMovement.PlayerStop();    // Part2c: Activate PlayerStop Method in PlayerMovement script.
            HudDisplay.SetActive(false);    // Part3: Deactivates gameplay hud.
            EndDisplay.SetActive(true);     // Part3: Activates end display.
            FailDisplay.SetActive(false);     // Part3: Activates end display.
        }
    }
}
