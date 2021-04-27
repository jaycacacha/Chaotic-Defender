using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameOverScript : MonoBehaviour
{
    public Text FinalScore;
    public Text FinalHighScore;
    public Text FinalCoins;
    public void Setup()
    {
        gameObject.SetActive(true);
        FinalHighScore.text = "HIGHSCORE:   " + Score.PlayerHighScore.ToString();
        FinalScore.text = "SCORE:   " + Score.ScoreValue.ToString();
        FinalCoins.text = "COINS:   " + Score.TotalCoins.ToString() + " (+" + Score.CoinStorage.ToString() + ")";
    }
    public void InactiveSetup()
    {
        gameObject.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
        Score.ScoreValue = 0;
        Score.CoinStorage = 0;
        PlayerControl.isDead = false;
        Score.KillsPerRound = 0;
        Score.DeathRound = 0;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        Score.GameoverStatus = true;
        Score.ScoreValue = 0;
        Score.CoinStorage = 0;
        PlayerControl.isDead = false;
        Score.KillsPerRound = 0;
        Score.DeathRound = 0;
    }
}
