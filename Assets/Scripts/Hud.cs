using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    public void KeyFound()      // Part3: When KeyFound method is activated from Key script...
    {
        Transform keyDisplay = transform.Find("KeyDisplay");    // Part3: Activate KeyFound method from Hud script
        keyDisplay.gameObject.SetActive(true);                  // Part3: Activate KeyFound method from Hud script
    }
}
