using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class LeaderBoardManager : Singleton<LeaderBoardManager>
{
    void Initializer()
    {
        ShowLeaderBoard();
    }

    void ShowLeaderBoard()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIptKdiJkJEAIQBw");
    }
}
