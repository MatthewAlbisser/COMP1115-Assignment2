using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndDisplay : MonoBehaviour      // Part3: Attached to HUD canvas object.
{
    public TextMeshProUGUI totalText;       // Part3: Declares timer text display.
    //public TextMeshProUGUI doorText;       // Part3: Declares timer text display.
    public TextMeshProUGUI timerText;       // Part3: Declares timer text display.
    public TextMeshProUGUI coinText;        // Part3: Declares coin text display.
    public Timer timer;                     // Part3: Declares Timer script.
    public Coins coins;                     // Part3: Declares Coins script.

    void Update()
    {
        totalText.text = "Level Time Limit: " + timer.TotalTime().ToString("F2");   // Part3: Displays level time limit to compare.
        timerText.text = "Time Remaining: " + timer.CurrentTime().ToString("F2");   // Part3: Displays time left.
        coinText.text = "Total Coins " + coins.CoinAmount().ToString() + " of 10";   // Part3: Displays text + Collected coin int.
    }
}
