using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
    string App_ID = "ca-app-pub-2362473887540939~9367628136";

    //test ID
    string Banner_Ad_ID = "ca-app-pub-3940256099942544/6300978111"; 
    //string Interstitial_Ad_ID = "ca-app-pub-3940256099942544/1033173712";
    //string Video_Ad_ID = "ca-app-pub-3940256099942544/5224354917";

    string Video_Ad_ID = "ca-app-pub-2362473887540939/5095082883";
    string Interstitial_Ad_ID = "ca-app-pub-2362473887540939/3100895814";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;

    public GameManager GameManager;
    public Button x2Button;

    PortalScript portalScript;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        MobileAds.Initialize(App_ID);

        RequestRewardBasedVideo();
        RequestInterstitial();
    }

    private void HandleRewardBasedVideoRewarded(object sender,EventArgs e)
    {
        Reward();
    }

    private void Reward()
    {   
        PlayerPrefs.SetInt("potCountBlue", PlayerPrefs.GetInt("potCountBlue") + PotionBlue.countBlue / 2);
        PlayerPrefs.SetInt("potCountRed", PlayerPrefs.GetInt("potCountRed") + PotionRed.countRed / 2);
        PlayerPrefs.SetInt("potCountYellow", PlayerPrefs.GetInt("potCountYellow") + PotionYellow.countYellow / 2);
        x2Button.interactable = false;
    }

    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(Banner_Ad_ID, AdSize.Banner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    public void ShowBannerAD()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_Ad_ID);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;        
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            GameManager.MainMenu();
        }
    }

    public void RequestRewardBasedVideo()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideo.LoadAd(request, Video_Ad_ID);        
    }

    public void ShowVideoRewardAd()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
           this.rewardBasedVideo.Show();
        }
    }

    // FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleOnAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleOnAdFailedToLoad event received");
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        GameManager.MainMenu();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
    }
}
