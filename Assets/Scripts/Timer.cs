using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour          // Attached to Timer Display canvas object. TMP HUD element.
{
    public float totalTime = 60.0f;         // Part2b: Starting value for the timer. public as stated in assignment.
    public float timeLeft;                  // Part2b: Holds remaining time from update.

    public PlayerMovement playerMovement;   // Part2c: Declares PlayerMovement script.

    public GameObject HudDisplay;           // Part3: Declares Hud canvas object.
    public GameObject EndDisplay;           // Part3: Declares end display canvas object.
    public GameObject FailDisplay;          // Part3: Declares end display canvas object.

    private bool timerOn = false;           // Part2c: Sets bool for timer. Starts off.

    void Start()
    {
        timeLeft = totalTime;               // Part2b: Sets timeleft to totalTime on game start.
    }
    void Update()
    {
        if (timerOn)                        // Part2b: If timerOn is set to true...
        {
            if (timeLeft > 0)                       // Part2b: And if the timer is more then 0...
            {
                timeLeft -= Time.deltaTime;         // Part2b: Decrease timeLeft by real time (in seconds).
            }
            else if (timeLeft <= 0.01f)             // Part2b: If the timer is equal or less then 0.01...
            {
                playerMovement.isMoving = false;    // Part1: player animation stops, showing a directional sprite.
                StopTimer();                        // Part2c: Activate StopTimer Method in Timer script.
                playerMovement.PlayerStop();        // Part2c: Activate PlayerStop Method in PlayerMovement script.
                HudDisplay.SetActive(false);        // Part3: Deactivates gameplay hud.
                EndDisplay.SetActive(true);         // Part3: Activates end display.
                FailDisplay.SetActive(true);        // Part3: Activates end display.
            }
        }
    }
        public void StartTimer()    // Part2c: When method is activated from LevelStart script...
    {
        timerOn = true;             // Part2c: Start up the timer.
    }
    public void StopTimer()         // Part2c: When method is activated...
    {
        timerOn = false;            // Part2c: Halt timer on current variable.
    }



    public float CurrentTime()
    {
        return timeLeft;          // Part3: Returns float for time left to display.
    }
    public float TotalTime()
    {
        return totalTime;          // Part3: Returns float for total time to display.
    }
}
