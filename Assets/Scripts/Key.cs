using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour        // Attach to key object.
{

    public Hud hud;                                 // Part1: Declares Hud script.
    public bool hasKey = false;                     // Part1: hasKey is false on start.
    private void OnTriggerEnter2D(Collider2D other) // Part1: When collision with the key...
    {
        if (other.CompareTag("Player"))             // Part1: Is an object with the player tag...
        {
            hasKey = true;                          // Part1: Sets hasKey to true.
            gameObject.SetActive(false);            // Part1: deactivates key object.
            hud.KeyFound();                         // Part3: Activate KeyFound method from Hud script.
        }
    }
}