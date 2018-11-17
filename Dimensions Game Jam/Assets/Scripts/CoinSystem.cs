using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour {
   
    public int coins = 0;
    public Text countText;

    void Start()
    {
  
        SetCountText();
    }

 
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        if (col.gameObject.tag == "Coin")
        {
            coins++;
            countText.text = "Coins:" + coins;
            SetCountText();
        }
        
    }

    void SetCountText()
    {
        countText.text = "Coins:" + coins;
    }
}
