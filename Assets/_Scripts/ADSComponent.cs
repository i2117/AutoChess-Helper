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
        appId = "";
#elif UNITY_IPHONE
        appId = "";
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
        adUnitId = "";
        // GOOGLE TEST ID
        //adUnitId = "";
#elif UNITY_IPHONE
        adUnitId = "";
#else
        adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the bottom of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        //.AddTestDevice("")

        // Load the banner with the request.
        bannerView.LoadAd(request);
        bannerView.Show();
    }

}

