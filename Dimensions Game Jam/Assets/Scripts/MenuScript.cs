using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void PlayNormalGame()
    {
        SceneManager.LoadScene("fixedScene");
    }

    public void PlayEndlessGame()
    {
        SceneManager.LoadScene("EndlessScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RetryGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CoinSystem.coins = 0;
        CoinSystem.spentCoins = 0;
        GameObject.Find("Alien1_PH").GetComponent<CoinSystem>().SetCountText();
        EndlessScore.score = 0;
    
    }
}
