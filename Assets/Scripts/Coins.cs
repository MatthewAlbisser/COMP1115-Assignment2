using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour                      // Attached to all Coin objects.
{
    public static List<int> coinList = new List<int>(); // Part2a: Declares a static list for coin collection.
    private int coinValue = 1;                          // Part2a: Declares an int value of 1 to each coin.

    private void OnTriggerEnter2D(Collider2D other)     // Part2a: When a collision with the Coin...
    {
        if (other.CompareTag("Player"))                 // Part2a: Is an object with the player tag...
        {
            coinList.Add(coinValue);        // Part2a: Adds value to total number in list.
            gameObject.SetActive(false);    // Part2a: Remove coin from scene. Destroy(gameObject);
        }
    }
    public int CoinAmount()             // Part3: When CoinAmount method is activated...
    {
        return coinList.Count;          // Part3: Returns coin amount to the hud.
    }
}