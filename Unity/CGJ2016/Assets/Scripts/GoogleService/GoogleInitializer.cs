using UnityEngine;
using System.Collections;

public class GoogleInitializer
{

    public bool mWaitingForAuth = false;

    AchievementManager achievementManager = null;

    LeaderBoardManager leaderBoardManager = null;

    User userData = null;

    public GoogleInitializer()
    {
        GooglePlayInit();
    }

    void GooglePlayInit()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();
        GooglePlayAuthentication();
        this.userData = DataService.Instance.GetUserData();
    }

    void GooglePlayAuthentication()
    {
        if (!Social.localUser.authenticated)
        {
            // Authenticate
            mWaitingForAuth = true;
            Social.localUser.Authenticate((bool success) =>
            {
                mWaitingForAuth = false;
                if (success)
                {
                    string token = GooglePlayGames.PlayGamesPlatform.Instance.GetToken();
                    SendDataToGooglePlay();
                }
                else {
                }
            });
        }
        else {
            // Sign out!
            //((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
        }
    }

    void InitAchievementSingleton()
    {
        this.achievementManager = AchievementManager.Instance;
    }

    void InitLeaderBoardSingleton()
    {
        this.leaderBoardManager = LeaderBoardManager.Instance;
    }

    void SendDataToGooglePlay()
    {
        Social.ReportScore(DataService.Instance.GetUserData().HighScore, "CgkIptKdiJkJEAIQBw", (bool success) =>
        {
            // handle success or failure
        });

    }
}
