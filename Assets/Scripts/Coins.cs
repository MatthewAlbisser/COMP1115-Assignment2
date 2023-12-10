using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public List<int> coinList = new List<int>();    // Part2: Declares a list for coin collection.
    private int coinValue = 1;                      // Part2: Declares an int value of 1 to each coin.
    private void OnTriggerEnter2D(Collider2D other) // Part2: When a collision with the Coin...
    {
        if (other.CompareTag("Player"))             // Part2: Is an object with the player tag...
        {
            GetCoin();                              // Part2: Activate GetCoin Method.
        }
    }

    public void GetCoin()
    {
        coinList.Add(coinValue);                    // Part2: Adds value to total number in list.
        Debug.Log("Current Coin List: " + string.Join(", ", coinList)); // Log the entire coinList
        DebugginOut();
        gameObject.SetActive(false);                // Part2: Remove coin from scene.
    }
    public void DebugginOut()
    {
        Debug.Log("Total Coins Collected: " + coinList.Count);
    }
}