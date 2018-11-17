using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CoinSystem : MonoBehaviour {
   
    public static int coins = 0;
    static int spentCoins = 0;
    public Text countText;
    public int coinsNeeded;
    public AudioSource noise;
    public AudioSource noise2;

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
            noise2.Play();
        }
        noise.Play();
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
