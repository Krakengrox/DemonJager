using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class BannerViewManager
{
    BannerView bannerView = null;

    public BannerViewManager()
    {
        InitBanner();
    }

    public void InitBanner()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9488670103027616/4075321281";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "ca-app-pub-9488670103027616/4075321281";
#endif

        // Create a 320x50 banner at the top of the screen.
        AdSize adSize = new AdSize(400, 50);
        this.bannerView = new BannerView(adUnitId, adSize, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        this.bannerView.Show();
    }
    public void ShowBanner()
    {
        this.bannerView.Show();


    }
    public void HideBanner()
    {
        this.bannerView.Hide();

    }

}
