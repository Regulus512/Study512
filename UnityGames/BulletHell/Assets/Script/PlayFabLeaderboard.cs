using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] scoreUIs, timerUIs;

    private void OnEnable()
    {
        RequestLeaderboard();
    }


    //Get the players with the top 10 high scores in the game
    public void RequestLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 9
        }, result => DisplayScoreBoard(result), FailureCallback);
    }

    private void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    public void DisplayScoreBoard(GetLeaderboardResult result)
    {
        for(int i = 0; i< result.Leaderboard.Count; i++)
        {
            scoreUIs[i].text = result.Leaderboard[i].StatValue.ToString();
        }
        foreach (var res in result.Leaderboard)
        {
            print($"[Score] {res.Position} PlafabID: {res.PlayFabId} StatValue: {res.StatValue}");
        }
    }
}
