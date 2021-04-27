using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public Text TotalKills;
    public Text TotalDeaths;
    public Text HighScore;


    void Start()
    {
        TotalKills.text = "KILL(S):  " + PlayerPrefs.GetInt("Kills").ToString();
        TotalDeaths.text = "DEATH(S):  " + PlayerPrefs.GetInt("Death").ToString();
        HighScore.text = "HIGHSCORE:  " + PlayerPrefs.GetInt("HighScore").ToString();


    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ResetDeathKill()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("FirstPlay", 0);
        PlayerPrefs.SetInt("Gameover", 0);
        PlayerPrefs.DeleteKey("Kills");
        PlayerPrefs.DeleteKey("Death");
        PlayerPrefs.SetFloat("TimeBetweenShotDefault", 1.1f);
        PlayerPrefs.SetInt("DefaultMaxHP", 3);
        PlayerPrefs.SetInt("HeartMaxUpgrade", 0);
        PlayerPrefs.SetInt("BulletMaxUpgrade", 0);
        PlayerPrefs.SetInt("CoinMaxUpgrade", 0);
        PlayerPrefs.SetInt("CoinMultiplier", 1);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("HeartFirstUpgradeBool", 0);
        PlayerPrefs.SetInt("HeartSecondUpgradeBool", 0);
        PlayerPrefs.SetInt("HeartThirdUpgradeBool", 0);
        PlayerPrefs.SetInt("HeartFourthUpgradeBool", 0);
        PlayerPrefs.SetInt("HeartFifthUpgradeBool", 0);

        PlayerPrefs.SetInt("BulletFirstUpgradeBool", 0);
        PlayerPrefs.SetInt("BulletSecondUpgradeBool", 0);
        PlayerPrefs.SetInt("BulletThirdUpgradeBool", 0);
        PlayerPrefs.SetInt("BulletFourthUpgradeBool", 0);
        PlayerPrefs.SetInt("BulletFifthUpgradeBool", 0);

        PlayerPrefs.SetInt("CoinFirstUpgradeBool", 0);
        PlayerPrefs.SetInt("CoinSecondUpgradeBool", 0);
        PlayerPrefs.SetInt("CoinThirdUpgradeBool", 0);
        PlayerPrefs.SetInt("CoinFourthUpgradeBool", 0);
        PlayerPrefs.SetInt("CoinFifthUpgradeBool", 0);
        TotalKills.text = "KILL(S):  " + PlayerPrefs.GetInt("Kills").ToString();
        TotalDeaths.text = "DEATH(S):  " + PlayerPrefs.GetInt("Death").ToString();
        HighScore.text = "HIGHSCORE:  " + PlayerPrefs.GetInt("HighScore").ToString();
    }

}
