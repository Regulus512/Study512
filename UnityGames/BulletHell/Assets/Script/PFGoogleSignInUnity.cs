using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PFGoogleSignInUnity : MonoBehaviour
{
    public Text loginUIText;
    void Start()
    {
        if(Application.platform==RuntimePlatform.Android)
        {
            PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
            Debug.Log("android start");
        }
        else
        {
            //custom playfab login
            var request = new LoginWithCustomIDRequest
            {
                CustomId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
            };
            PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
        }

    }

    void OnSuccess(LoginResult result)
    {
        print("Successful login/account create");
    }
    void OnError(PlayFabError error)
    {
        print("Error creating acount"); ;
        print(error.GenerateErrorReport());
    }


    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            PlayGamesPlatform.Instance.RequestServerSideAccess(false, ProcessServerAuthCode);
        }
        else
            loginUIText.text = status.ToString();
    }

    private void ProcessServerAuthCode(string serverAuthCode)
    {
        Debug.Log("Server Auth Code: " + serverAuthCode);

        var request = new LoginWithGooglePlayGamesServicesRequest
        {
            ServerAuthCode = serverAuthCode,
            CreateAccount = true,
            TitleId = PlayFabSettings.TitleId
        };

        PlayFabClientAPI.LoginWithGooglePlayGamesServices(request, OnLoginWithGooglePlayGamesServicesSuccess, OnLoginWithGooglePlayGamesServicesFailure);
    }

    private void OnLoginWithGooglePlayGamesServicesSuccess(LoginResult result)
    {
        Debug.Log("PF Login Success LoginWithGooglePlayGamesServices");
        loginUIText.text = "PF Login Success LoginWithGooglePlayGamesServices";
    }

    private void OnLoginWithGooglePlayGamesServicesFailure(PlayFabError error)
    {
        Debug.Log("PF Login Failure LoginWithGooglePlayGamesServices: " + error.GenerateErrorReport());
        loginUIText.text = "PF Login Failure LoginWithGooglePlayGamesServices: " + error.GenerateErrorReport();
    }



    //리더보드
    public void SubmitScore(int playerScore, int playerTime)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "Score",
                Value = playerScore
            },
            new StatisticUpdate
            {
                StatisticName = "Time",
                Value = playerTime
            }
        }
        }, result => OnStatisticsUpdated(result), FailureCallback);
    }

    private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult)
    {
        Debug.Log("Successfully submitted high score");
    }

    private void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());

        leaderBoardTest.text = error.GenerateErrorReport();
    }

    public Text leaderBoardTest;

    //Get the players with the top 10 high scores in the game
    public void RequestLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 3
        }, result => DisplayLeaderboard(result), FailureCallback);

        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "Time",
            StartPosition = 0,
            MaxResultsCount = 3
        }, result => DisplayLeaderboard(result), FailureCallback);
    }

    public void DisplayLeaderboard(GetLeaderboardResult result)
    {
        foreach(var res in result.Leaderboard)
        {
            print($"DisplayName: {res.DisplayName}, PlafabID: {res.PlayFabId}" +
                $"StatValue: {res.StatValue}, Position {res.Position}\n");
        }
    }

}