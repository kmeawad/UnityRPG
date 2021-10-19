using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPickUp : MonoBehaviour
{
    //store the coin quantity as well as coin display text
    public float coin = 0f;
    public Text coinDisplay;

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the hero collides with the coin then increase the coin quantity by 10 and destroy the coin
        if(other.gameObject.CompareTag("Coin")) 
        {
            coin += 10;
            Destroy(other.gameObject);
            //update the coin display
            UpdateCoins();
        }
    }
   
    public void UpdateCoins()
    {
        //update the coin display to the current number of coins
        coinDisplay.text = coin.ToString();
    }
}
