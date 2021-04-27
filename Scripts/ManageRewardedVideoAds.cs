using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;

public class ManageRewardedVideoAds : MonoBehaviour
{
    string rewardedVideoAd = "ca-app-pub-3940256099942544/5224354917";
    //production-key
    //string rewardedVideoAd = "ca-app-pub-1983050787204104/9539200012";

    //string rewardedVideoAdTest = "ca-app-pub-3940256099942544/5224354917";
    private RewardedAd rewardedAd;

    public static int TotalCoins;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        rewardedAd = new RewardedAd(rewardedVideoAd);
        // Called when an ad request has successfully loaded.
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest requestRewardVideoAd = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(requestRewardVideoAd);
    }
    public void ShowRewardedVideoAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
    private void Update()
    {
        TotalCoins = PlayerPrefs.GetInt("Coins");
    }

    public void CreateAndLoadRewardedAd()
    {

        rewardedAd = new RewardedAd(rewardedVideoAd);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        SSTools.ShowMessage("No Ads Available", SSTools.Position.bottom, SSTools.Time.twoSecond);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        SSTools.ShowMessage("No Ads Available", SSTools.Position.bottom, SSTools.Time.twoSecond);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        SSTools.ShowMessage("Reward Received!", SSTools.Position.bottom, SSTools.Time.twoSecond);

        PlayerPrefs.SetInt("Coins", TotalCoins + 30);
    }
}
