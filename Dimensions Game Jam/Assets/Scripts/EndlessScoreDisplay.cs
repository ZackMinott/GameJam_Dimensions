using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessScoreDisplay : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public Text scoreText;
    public Text coinText;
    public Text finalScoreText;
    public GameObject backButton;
    int score;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        score = scoreText.GetComponent<EndlessScore>().GetScore();
        if (player1.GetComponent<PlayerController>().lives <= 0 || player2.GetComponent<PlayerController>().lives <= 0)
        {
            finalScoreText.enabled = true;
            scoreText.enabled = false;
            coinText.enabled = false;
            backButton.SetActive(true);
            player1.SetActive(false);
            player2.SetActive(false);
            scoreText.GetComponent<EndlessScore>().enabled = false;
            finalScoreText.text = "FINAL SCORE: " + score;
        }
	}
}
