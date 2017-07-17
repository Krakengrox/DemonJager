using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsManager : Singleton<AdsManager>
{
    public string unityAdsID = "1058118";

    public System.Action finishVideo, skipedVideo;

    public System.Action errorVideo;

    protected override void Awake()
    {
        this.isPersistent = false;
        base.Awake();
    }

    public void LaunchAdvertisement()
    {
        if (Advertisement.IsReady())
        {
            var option = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", option);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                errorVideo();
                Debug.Log("fallo");
                break;
            case ShowResult.Skipped:
                skipedVideo();
                break;
            case ShowResult.Finished:
                finishVideo();
                do
                {
                    EnemyManager.instance.Enemies[0].Kill(false);
                    EnemyManager.instance.Enemies[0].RemoveFromTargetting();
                } while (EnemyManager.instance.Enemies.Count >= 1);

                break;
        }
    }

    public bool AdvertisementIsReady()
    {
        return Advertisement.IsReady();
    }
}
