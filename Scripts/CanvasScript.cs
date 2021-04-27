using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{


    public Text MultiplierText;
    private void Start()
    {
        if (PlayerPrefs.GetInt("CoinFirstUpgradeBool") == 0)
        {
            MultiplierText.text = "x" + 1;
        }
        if (PlayerPrefs.GetInt("CoinFirstUpgradeBool") == 1)
        {
            MultiplierText.text = "x" + PlayerPrefs.GetInt("CoinMultiplier").ToString();
        }

    }
    public void PauseGame()
    {

        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        Score.ScoreValue = 0;
        Score.CoinStorage = 0;
        Score.KillsPerRound = 0;
        Score.DeathRound = 0;
        EnemyScript.isVisible = false;
    }
    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

}
