using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour {
   
    public static int coins = 0;
    public Text countText;

    void Start()
    {
  
        SetCountText();
    }

 
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Coin")
        {
            coins++;
            //countText.text = "Coins:" + coins;
            SetCountText();
        }

        Destroy(col.gameObject);

    }

    void SetCountText()
    {
        countText.text = "Coins: " + coins;
    }

    
}
