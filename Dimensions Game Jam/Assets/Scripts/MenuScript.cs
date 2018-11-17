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
}
