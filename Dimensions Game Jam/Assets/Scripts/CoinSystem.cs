using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour {
   
    public static int coins = 0;
    public static int spentCoins = 0;
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
            SetCountText();
        }
        if (coins >= 100)
        {
            transform.gameObject.GetComponent<PlayerController>().lives++;
            coins -= 100;
            spentCoins += 100;
            Debug.Log(transform.gameObject.name + " gained life");
        }
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
