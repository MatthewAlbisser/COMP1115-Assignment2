using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour      // Part3: Attached to HUD canvas object.
{
    public TextMeshProUGUI timerText;       // Part3: Declares timer text display.
    public TextMeshProUGUI coinText;        // Part3: Declares coin text display.
    public Timer timer;                     // Part3: Declares Timer script.
    public Coins coins;                     // Part3: Declares Coins script.

    void Update()
    {
        timerText.text = "TIME: " + timer.CurrentTime().ToString("F2"); // Part3: Displays text + timeLeft by 2 decimalpoints.
        coinText.text = "COINS:" + coins.CoinAmount().ToString();       // Part3: Displays text + Collected coin int.
    }
}
