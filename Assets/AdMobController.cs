using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobController : MonoBehaviour
{
    private InterstitialAd intersitional;
    private BannerView banner;

#if UNITY_IOS
    private string appId="ca-app-pub-4962234576866611~3588528660";
    private string intersitionalId="ca-app-pub-4962234576866611/5995200157";
    
    private string bannerId="ca-app-pub-4962234576866611/8328869393";
#else
    private string appId="ca-app-pub-4962234576866611~5349626885";
    private string intersitionalId="ca-app-pub-4962234576866611/8902168514";

    private string bannerId="ca-app-pub-4962234576866611/9835666801";
#endif


    void Start(){
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => {
            LoadLoadInterstitialAd();
            CreateBannerView();
            LoadBannerAd();
        });
        
        //RequestConfigurationAd();
        //RequestBannerAd();
    }

     AdRequest AdRequestBuild(){
         return new AdRequest.Builder().Build();
     }

    private InterstitialAd _interstitialAd;

    private BannerView _bannerView;
    
    public void LoadLoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(intersitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }


      public void showIntersitionalAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
      }

    public void CreateBannerView()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);
    }

    public void LoadBannerAd()
    {
        // create an instance of a banner view first.
        if(_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }

    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }
}

