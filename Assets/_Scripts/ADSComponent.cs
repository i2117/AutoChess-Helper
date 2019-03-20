using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class ADSComponent : MonoBehaviour
{
    private BannerView bannerView;

    public void Awake()
    {
        string appId;
#if UNITY_ANDROID
        appId = "ca-app-pub-7615586127647226~2065441665";
#elif UNITY_IPHONE
        appId = "ca-app-pub-7615586127647226~8036480308";
#else
        appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    private void RequestBanner()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-7615586127647226/7645071400";
        // GOOGLE TEST ID
        //adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        adUnitId = "ca-app-pub-7615586127647226/9918082777";
#else
        adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the bottom of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        //.AddTestDevice("54D28902282B12383990E3CD646C4BDB")

        // Load the banner with the request.
        bannerView.LoadAd(request);
        bannerView.Show();
    }

}

