using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CoinSystem : MonoBehaviour {
   
    public static int coins = 0;
    public static int spentCoins = 0;
    public int coinsNeeded = 100;
    public Text countText;
    public AudioSource collectNoise;
    public AudioSource healNoise;

    void Start()
    {
  
        SetCountText();
    }

 
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Coin")
        {
            coins++;
            SetCountText();
        }
        if (coins >= coinsNeeded)
        {
            transform.gameObject.GetComponent<PlayerController>().lives++;
            coins -= coinsNeeded;
            spentCoins += coinsNeeded;
            healNoise.Play();
        }
        collectNoise.Play();
        Destroy(col.gameObject);

    }

    public void SetCountText()
    {
        countText.text = "Gems: " + (coins + spentCoins);
    }

    public int getCoinScore()
    {
        return 5 * (coins + spentCoins);
    }

    
}
