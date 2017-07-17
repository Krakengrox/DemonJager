using UnityEngine;
using System.Collections;

public class AchievementManager : Singleton<AchievementManager>
{

    void Initializer()
    {

    }

    void ShowAchievementBoard()
    {
        Social.ShowAchievementsUI();
    }
}
