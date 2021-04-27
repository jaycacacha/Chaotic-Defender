using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text TotalCoins, BulletCost, HeartCost, CoinCost;
    public int TotalCoinsVariable;
    public Image[] HeartUpgrade;
    public Image[] BulletUpgrade;
    public Image[] CoinUpgrade;
    public Image HeartUpgradeCoin, BulletUpgradeCoin, CoinUpgradeCoin;
    public GameObject HeartUpgradeButton, BulletUpgradeButton, CoinUpgradeButton;
    private int TotalHeartClicks, TotalCoinClicks, TotalBulletClicks;
    private int HeartFirstUpgrade = 200, HeartSecondUpgrade = 400, HeartThirdUpgrade = 800, HeartFourthUpgrade = 1200, HeartFifthUpgrade = 2000,
    BulletFirstUpgrade = 500, BulletSecondUpgrade = 800, BulletThirdUpgrade = 1500, BulletFourthUpgrade = 2000, BulletFifthUpgrade = 3000,
    CoinFirstUpgrade = 500, CoinSecondUpgrade = 900, CoinThirdUpgrade = 1700, CoinFourthUpgrade = 2300, CoinFifthUpgrade = 3000;

    private int HeartFirstUpgradeBool, HeartSecondUpgradeBool, HeartThirdUpgradeBool, HeartFourthUpgradeBool, HeartFifthUpgradeBool,
    BulletFirstUpgradeBool, BulletSecondUpgradeBool, BulletThirdUpgradeBool, BulletFourthUpgradeBool, BulletFifthUpgradeBool,
    CoinFirstUpgradeBool, CoinSecondUpgradeBool, CoinThirdUpgradeBool, CoinFourthUpgradeBool, CoinFifthUpgradeBool,

    HeartMaxUpgrade, BulletMaxUpgrade, CoinMaxUpgrade;
    // Start is called before the first frame update
    private bool HeartButtonDisabled = false, BulletButtonDisabled = false, CoinButtonDisabled = false;
    private void Start()
    {

        TotalHeartClicks = 1;
        TotalCoinClicks = 1;
        TotalBulletClicks = 1;
        HeartMaxUpgrade = PlayerPrefs.GetInt("HeartMaxUpgrade");
        BulletMaxUpgrade = PlayerPrefs.GetInt("BulletMaxUpgrade");
        CoinMaxUpgrade = PlayerPrefs.GetInt("CoinMaxUpgrade");
    }
    private void Update()
    {
        TotalCoinsVariable = PlayerPrefs.GetInt("Coins");
        TotalCoins.text = TotalCoinsVariable.ToString();

        HeartMaxUpgrade = PlayerPrefs.GetInt("HeartMaxUpgrade");
        BulletMaxUpgrade = PlayerPrefs.GetInt("BulletMaxUpgrade");
        CoinMaxUpgrade = PlayerPrefs.GetInt("CoinMaxUpgrade");

        HeartFirstUpgradeBool = PlayerPrefs.GetInt("HeartFirstUpgradeBool");
        HeartSecondUpgradeBool = PlayerPrefs.GetInt("HeartSecondUpgradeBool");
        HeartThirdUpgradeBool = PlayerPrefs.GetInt("HeartThirdUpgradeBool");
        HeartFourthUpgradeBool = PlayerPrefs.GetInt("HeartFourthUpgradeBool");
        HeartFifthUpgradeBool = PlayerPrefs.GetInt("HeartFifthUpgradeBool");

        BulletFirstUpgradeBool = PlayerPrefs.GetInt("BulletFirstUpgradeBool");
        BulletSecondUpgradeBool = PlayerPrefs.GetInt("BulletSecondUpgradeBool");
        BulletThirdUpgradeBool = PlayerPrefs.GetInt("BulletThirdUpgradeBool");
        BulletFourthUpgradeBool = PlayerPrefs.GetInt("BulletFourthUpgradeBool");
        BulletFifthUpgradeBool = PlayerPrefs.GetInt("BulletFifthUpgradeBool");

        CoinFirstUpgradeBool = PlayerPrefs.GetInt("CoinFirstUpgradeBool");
        CoinSecondUpgradeBool = PlayerPrefs.GetInt("CoinSecondUpgradeBool");
        CoinThirdUpgradeBool = PlayerPrefs.GetInt("CoinThirdUpgradeBool");
        CoinFourthUpgradeBool = PlayerPrefs.GetInt("CoinFourthUpgradeBool");
        CoinFifthUpgradeBool = PlayerPrefs.GetInt("CoinFifthUpgradeBool");

        if (HeartFirstUpgradeBool == 1)
        {
            HeartUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartCost.text = HeartSecondUpgrade.ToString();
        }
        if (HeartSecondUpgradeBool == 1)
        {
            HeartUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartCost.text = HeartThirdUpgrade.ToString();
        }
        if (HeartThirdUpgradeBool == 1)
        {
            HeartUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartUpgrade[2].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartCost.text = HeartFourthUpgrade.ToString();

        }
        if (HeartFourthUpgradeBool == 1)
        {
            HeartUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartUpgrade[2].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartUpgrade[3].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            HeartCost.text = HeartFifthUpgrade.ToString();
        }

        if (HeartFirstUpgradeBool == 0 && HeartSecondUpgradeBool == 0 && HeartThirdUpgradeBool == 0 && HeartFourthUpgradeBool == 0 && HeartMaxUpgrade == 0)
        {
            for (int i = 0; i < HeartUpgrade.Length; i++)
            {
                HeartUpgrade[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            }
            HeartUpgradeCoin.GetComponent<Image>().enabled = true;
            HeartUpgradeButton.SetActive(true);
            HeartCost.text = HeartFirstUpgrade.ToString();
            HeartCost.color = new Color32(255, 192, 8, 255);
        }

        if (BulletFirstUpgradeBool == 1)
        {
            BulletUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletCost.text = BulletSecondUpgrade.ToString();
        }
        if (BulletSecondUpgradeBool == 1)
        {
            BulletUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletCost.text = BulletThirdUpgrade.ToString();
        }
        if (BulletThirdUpgradeBool == 1)
        {
            BulletUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletUpgrade[2].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletCost.text = BulletFourthUpgrade.ToString();

        }
        if (BulletFourthUpgradeBool == 1)
        {
            BulletUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletUpgrade[2].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletUpgrade[3].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            BulletCost.text = BulletFifthUpgrade.ToString();
        }

        if (BulletFirstUpgradeBool == 0 && BulletSecondUpgradeBool == 0 && BulletThirdUpgradeBool == 0 && BulletFourthUpgradeBool == 0 && BulletMaxUpgrade == 0)
        {
            for (int i = 0; i < BulletUpgrade.Length; i++)
            {
                BulletUpgrade[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            }

            BulletUpgradeCoin.GetComponent<Image>().enabled = true;
            BulletUpgradeButton.SetActive(true);
            BulletCost.text = BulletFirstUpgrade.ToString();
            BulletCost.color = new Color32(255, 192, 8, 255);
        }

        if (CoinFirstUpgradeBool == 1)
        {
            CoinUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinCost.text = CoinSecondUpgrade.ToString();
        }
        if (CoinSecondUpgradeBool == 1)
        {
            CoinUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinCost.text = CoinThirdUpgrade.ToString();
        }
        if (CoinThirdUpgradeBool == 1)
        {
            CoinUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinUpgrade[2].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinCost.text = CoinFourthUpgrade.ToString();

        }
        if (CoinFourthUpgradeBool == 1)
        {
            CoinUpgrade[0].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinUpgrade[1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinUpgrade[2].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinUpgrade[3].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            CoinCost.text = CoinFifthUpgrade.ToString();
        }

        if (CoinFirstUpgradeBool == 0 && CoinSecondUpgradeBool == 0 && CoinThirdUpgradeBool == 0 && CoinFourthUpgradeBool == 0 && CoinMaxUpgrade == 0)
        {
            for (int i = 0; i < CoinUpgrade.Length; i++)
            {
                CoinUpgrade[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            }

            CoinUpgradeCoin.GetComponent<Image>().enabled = true;
            CoinUpgradeButton.SetActive(true);
            CoinCost.text = CoinFirstUpgrade.ToString();
            CoinCost.color = new Color32(255, 192, 8, 255);
        }

        if (TotalCoinsVariable >= HeartFirstUpgrade || TotalCoinsVariable >= HeartSecondUpgrade || TotalCoinsVariable >= HeartThirdUpgrade || TotalCoinsVariable >= HeartFourthUpgrade || TotalCoinsVariable >= HeartFifthUpgrade)
        {
            HeartCost.color = new Color32(254, 192, 8, 255);
        }
        else
        {
            HeartCost.color = new Color32(255, 0, 0, 255);
        }
        if (TotalCoinsVariable >= BulletFirstUpgrade || TotalCoinsVariable >= BulletSecondUpgrade || TotalCoinsVariable >= BulletThirdUpgrade || TotalCoinsVariable >= BulletFourthUpgrade || TotalCoinsVariable >= BulletFifthUpgrade)
        {
            BulletCost.color = new Color32(254, 192, 8, 255);
        }
        else
        {
            BulletCost.color = new Color32(255, 0, 0, 255);
        }
        if (TotalCoinsVariable >= CoinFirstUpgrade || TotalCoinsVariable >= CoinSecondUpgrade || TotalCoinsVariable >= CoinThirdUpgrade || TotalCoinsVariable >= CoinFourthUpgrade || TotalCoinsVariable >= CoinFifthUpgrade)
        {
            CoinCost.color = new Color32(254, 192, 8, 255);
        }
        else
        {
            CoinCost.color = new Color32(255, 0, 0, 255);
        }
        if (HeartMaxUpgrade == 1)
        {
            TotalHeartClicks = 1;
            for (int i = 0; i < HeartUpgrade.Length; i++)
            {
                HeartUpgrade[i].GetComponent<Image>().color = new Color32(254, 192, 8, 255);

            }
            HeartUpgradeCoin.GetComponent<Image>().enabled = false;
            HeartUpgradeButton.SetActive(false);
            HeartCost.text = "MAX";
            HeartCost.color = new Color32(255, 0, 0, 255);

        }

        if (BulletMaxUpgrade == 1)
        {
            TotalBulletClicks = 1;
            for (int i = 0; i < BulletUpgrade.Length; i++)
            {
                BulletUpgrade[i].GetComponent<Image>().color = new Color32(254, 192, 8, 255);

            }
            BulletUpgradeCoin.GetComponent<Image>().enabled = false;
            BulletUpgradeButton.SetActive(false);
            BulletCost.text = "MAX";
            BulletCost.color = new Color32(255, 0, 0, 255);

        }
        if (CoinMaxUpgrade == 1)
        {
            TotalCoinClicks = 1;
            for (int i = 0; i < CoinUpgrade.Length; i++)
            {
                CoinUpgrade[i].GetComponent<Image>().color = new Color32(254, 192, 8, 255);

            }
            CoinUpgradeCoin.GetComponent<Image>().enabled = false;
            CoinUpgradeButton.SetActive(false);
            CoinCost.text = "MAX";
            CoinCost.color = new Color32(255, 0, 0, 255);
        }
    }

    public void HeartPerClickUpgrade()
    {

        if (HeartButtonDisabled == false)
        {
            HeartUpgrade[TotalHeartClicks - 1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            TotalHeartClicks += 1;


            if (TotalCoinsVariable >= HeartFirstUpgrade && HeartFirstUpgradeBool == 0)
            {
                HeartFirstUpgradeBool = 1;
                PlayerPrefs.SetInt("HeartFirstUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - HeartFirstUpgrade);
                PlayerPrefs.SetInt("DefaultMaxHP", 4);
                HeartCost.text = HeartSecondUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= HeartSecondUpgrade && HeartSecondUpgradeBool == 0 && HeartFirstUpgradeBool == 1)
            {
                HeartSecondUpgradeBool = 1;
                PlayerPrefs.SetInt("HeartSecondUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - HeartSecondUpgrade);
                PlayerPrefs.SetInt("DefaultMaxHP", 5);
                HeartCost.text = HeartThirdUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= HeartThirdUpgrade && HeartThirdUpgradeBool == 0 && HeartSecondUpgradeBool == 1)
            {
                HeartThirdUpgradeBool = 1;
                PlayerPrefs.SetInt("HeartThirdUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - HeartThirdUpgrade);
                PlayerPrefs.SetInt("DefaultMaxHP", 6);
                HeartCost.text = HeartFourthUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= HeartFourthUpgrade && HeartFourthUpgradeBool == 0 && HeartThirdUpgradeBool == 1)
            {
                HeartFourthUpgradeBool = 1;
                PlayerPrefs.SetInt("HeartFourthUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - HeartFourthUpgrade);
                PlayerPrefs.SetInt("DefaultMaxHP", 7);
                HeartCost.text = HeartFifthUpgrade.ToString();

            }

            else if (TotalCoinsVariable >= HeartFifthUpgrade && HeartFifthUpgradeBool == 0 && HeartFourthUpgradeBool == 1)
            {
                HeartFifthUpgradeBool = 1;
                PlayerPrefs.SetInt("HeartFifthUpgradeBool", 1);
                PlayerPrefs.SetInt("HeartMaxUpgrade", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - HeartFifthUpgrade);
                PlayerPrefs.SetInt("DefaultMaxHP", 8);

            }
            else
            {
                HeartButtonDisabled = true;
            }


        }

    }
    public void BulletPerClickUpgrade()
    {
        if (BulletButtonDisabled == false)
        {
            BulletUpgrade[TotalBulletClicks - 1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            TotalBulletClicks += 1;


            if (TotalCoinsVariable >= BulletFirstUpgrade && BulletFirstUpgradeBool == 0)
            {
                BulletFirstUpgradeBool = 1;
                PlayerPrefs.SetInt("BulletFirstUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - BulletFirstUpgrade);
                PlayerPrefs.SetFloat("TimeBetweenShotDefault", 1.0f);
                BulletCost.text = BulletFirstUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= BulletSecondUpgrade && BulletSecondUpgradeBool == 0 && BulletFirstUpgradeBool == 1)
            {
                BulletSecondUpgradeBool = 1;
                PlayerPrefs.SetInt("BulletSecondUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - BulletSecondUpgrade);
                PlayerPrefs.SetFloat("TimeBetweenShotDefault", 0.9f);
                BulletCost.text = BulletSecondUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= BulletThirdUpgrade && BulletThirdUpgradeBool == 0 && BulletSecondUpgradeBool == 1)
            {
                BulletThirdUpgradeBool = 1;
                PlayerPrefs.SetInt("BulletThirdUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - BulletThirdUpgrade);
                PlayerPrefs.SetFloat("TimeBetweenShotDefault", 0.85f);
                BulletCost.text = BulletThirdUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= BulletFourthUpgrade && BulletFourthUpgradeBool == 0 && BulletThirdUpgradeBool == 1)
            {
                BulletFourthUpgradeBool = 1;
                PlayerPrefs.SetInt("BulletFourthUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - BulletFourthUpgrade);
                PlayerPrefs.SetFloat("TimeBetweenShotDefault", 0.8f);
                BulletCost.text = BulletFourthUpgrade.ToString();

            }

            else if (TotalCoinsVariable >= BulletFifthUpgrade && BulletFifthUpgradeBool == 0 && BulletFourthUpgradeBool == 1)
            {
                BulletFifthUpgradeBool = 1;
                PlayerPrefs.SetInt("BulletFifthUpgradeBool", 1);
                PlayerPrefs.SetInt("BulletMaxUpgrade", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - BulletFifthUpgrade);
                PlayerPrefs.SetFloat("TimeBetweenShotDefault", 0.75f);

            }
            else
            {
                BulletButtonDisabled = true;
            }


        }
    }
    public void CoinPerClickUpgrade()
    {

        if (CoinButtonDisabled == false)
        {
            CoinUpgrade[TotalCoinClicks - 1].GetComponent<Image>().color = new Color32(254, 192, 8, 255);
            TotalCoinClicks += 1;


            if (TotalCoinsVariable >= CoinFirstUpgrade && CoinFirstUpgradeBool == 0)
            {
                CoinFirstUpgradeBool = 1;
                PlayerPrefs.SetInt("CoinFirstUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - CoinFirstUpgrade);
                PlayerPrefs.SetInt("CoinMultiplier", 2);
                CoinCost.text = CoinFirstUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= CoinSecondUpgrade && CoinSecondUpgradeBool == 0 && CoinFirstUpgradeBool == 1)
            {
                CoinSecondUpgradeBool = 1;
                PlayerPrefs.SetInt("CoinSecondUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - CoinSecondUpgrade);
                PlayerPrefs.SetInt("CoinMultiplier", 3);
                CoinCost.text = CoinSecondUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= CoinThirdUpgrade && CoinThirdUpgradeBool == 0 && CoinSecondUpgradeBool == 1)
            {
                CoinThirdUpgradeBool = 1;
                PlayerPrefs.SetInt("CoinThirdUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - CoinThirdUpgrade);
                PlayerPrefs.SetInt("CoinMultiplier", 4);
                CoinCost.text = CoinThirdUpgrade.ToString();
            }

            else if (TotalCoinsVariable >= CoinFourthUpgrade && CoinFourthUpgradeBool == 0 && CoinThirdUpgradeBool == 1)
            {
                CoinFourthUpgradeBool = 1;
                PlayerPrefs.SetInt("CoinFourthUpgradeBool", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - CoinFourthUpgrade);
                PlayerPrefs.SetInt("CoinMultiplier", 5);
                CoinCost.text = CoinFourthUpgrade.ToString();

            }

            else if (TotalCoinsVariable >= CoinFifthUpgrade && CoinFifthUpgradeBool == 0 && CoinFourthUpgradeBool == 1)
            {
                CoinFifthUpgradeBool = 1;
                PlayerPrefs.SetInt("CoinFifthUpgradeBool", 1);
                PlayerPrefs.SetInt("CoinMaxUpgrade", 1);
                PlayerPrefs.SetInt("Coins", TotalCoinsVariable - CoinFifthUpgrade);
                PlayerPrefs.SetInt("CoinMultiplier", 6);
            }
            else
            {
                CoinButtonDisabled = true;
            }


        }
    }
}
