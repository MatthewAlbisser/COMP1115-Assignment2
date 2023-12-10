using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour          // Part3: Attached to Timer Display canvas object. TMP HUD element.
{
    public float totalTime = 10f;           // Part2b: Starting value for the timer. public as stated in assignment.
    private float timeLeft;                 // Part2b: Holds remaining time from update.
    //private float doorTime;                 // Part2b: Holds remaining time from update.

    private bool timerOn = false;            // Part2c: Sets bool for timer. Starts off.

    void Start()
    {
        timeLeft = totalTime;               // Part2b: Sets timeleft to totalTime on game start.
    }
    void Update()
    {
        //doorTime = timeLeft;
        if (timerOn)
        {
            if (timeLeft > 0)                   // Part2b: If the timer is more then 0...
            {
                timeLeft -= Time.deltaTime;     // Part2b: Decrease timeLeft by real time (in seconds).
                Debug.Log("Timer:" + timeLeft);
            }
            else if (timeLeft <= 0.01f)         // Part2b: If the timer is equal or less then 0.01...
            {
                Debug.Log("GAME OVER");         // Part2b: change scene or add overlay for game overscreen/stop controls
                timerOn = false;                // Part2b: Stops the update from activating game over constantly.
            }
        }
    }

    public void StartTimer()    // Part2c: When method is activated...
    {
        timerOn = true;         // Part2c: Start up the timer.
    }
    public void StopTimer()     // Part2c: When method is activated...
    {
        timerOn = false;        // Part2c: Halt timer on current variable.
    }



    public float CurrentTime()
    {
        return timeLeft;          // Part3: Returns float for time left to display.
    }
    public float TotalTime()
    {
        return totalTime;          // Part3: Returns float for total time to display.
    }
//    public float DoorTime()
//    {
//        return doorTime;          // Part3: Returns float for open door time to display.
//    }

}
