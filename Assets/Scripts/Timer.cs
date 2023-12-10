using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour          // Part2b: Attached to Timer object.
{
    public float totalTime = 10f;           // Part2b: Starting value for the timer. public as stated in assignment.
    private float timeLeft;                 // Part2b: Holds remaining time from update.
    private bool timerOn = true;            // Part2c: Sets the timer to start.

    void Start()
    {
        timeLeft = totalTime;               // Part2b: Sets timeleft to totalTime on game start.
    }

    void Update()
    {
        if (timerOn)                            
        {
            if (timeLeft > 0)                   // Part2b: If the timer is more then 0...
            {
                timeLeft -= Time.deltaTime;     // Part2b: Decrease timeLeft by real time (in seconds).
                Debug.Log("Timer:" + timeLeft); // Part2b: Display a timer UI.
            }
            else if (timeLeft <= 0.01f)         // Part2b: If the timer is equal or less then 0.01...
            {
                Debug.Log("GAME OVER");         // Part2b: change scene or add overlay for game overscreen/stop controls
                timerOn = false;                // Part2b: Stops the update from activating game over constantly.
            }
        }
    }

    public void StopTimer()     // Part2c: When method is activated...
    {
        timerOn = false;        // Part2c: Halt timer on current variable.
    }
}