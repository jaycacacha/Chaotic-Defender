using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public static int ScoreValue;
    public static int KillsPerRound;
    public static int TotalKills;
    public static int DeathRound;
    public static int TotalDeath;
    public static int PlayerHighScore;
    public static int CoinStorage;
    public static int TotalCoins;
    public Text scoreBoard;
    public Text CoinBoard;
    public static bool GameoverStatus;

    void Start()
    {

        scoreBoard = GetComponent<Text>();
        PlayerHighScore = PlayerPrefs.GetInt("HighScore");
        TotalCoins = PlayerPrefs.GetInt("Coins");
        TotalKills = PlayerPrefs.GetInt("Kills");
        TotalDeath = PlayerPrefs.GetInt("Death");

    }

    // Update is called once per frame
    void Update()
    {
        CoinBoard.text = CoinStorage.ToString();
        scoreBoard.text = ScoreValue.ToString();
        if (ScoreValue > PlayerPrefs.GetInt("HighScore") && PlayerControl.isDead == true)
        {
            PlayerPrefs.SetInt("HighScore", ScoreValue);
            PlayerHighScore = ScoreValue;
        }
        if (CoinStorage > 0 && PlayerControl.isDead == true)
        {
            PlayerPrefs.SetInt("Coins", TotalCoins + CoinStorage);
           
        }
        if (KillsPerRound > 0)
        {
            PlayerPrefs.SetInt("Kills", KillsPerRound + TotalKills);
        }
        if (DeathRound > 0)
        {
            PlayerPrefs.SetInt("Death", TotalDeath + DeathRound);
        }
    }

}
