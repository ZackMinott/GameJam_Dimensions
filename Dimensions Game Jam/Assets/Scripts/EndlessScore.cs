using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessScore : MonoBehaviour {

    public static int score;
    public Text scoreText;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        SetScoreText();
    }

    void SetScoreText()
    {
        score = ((int)Time.time) + player.GetComponent<CoinSystem>().getCoinScore();
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }

}
