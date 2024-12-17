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
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
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
}