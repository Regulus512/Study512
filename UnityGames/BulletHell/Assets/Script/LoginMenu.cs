//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using UnityEngine.UI;
//using UnityEditor;
//using UnityEngine.SocialPlatforms;
//using UnityEngine.SceneManagement;
//using PlayFab;
//using PlayFab.ClientModels;
//using PlayFab.ServerModels;
//using System;



public class LoginMenu : MonoBehaviour
{
    // Start is called before the first frame update

    //public static string User_ID = null;

    //void Start()
    //{

    //    PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
    //        .AddOauthScope("profile")
    //        .RequestServerAuthCode(false)
    //        .Build();
    //    PlayGamesPlatform.InitializeInstance(config);
    //    PlayGamesPlatform.Activate();

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //public void OnClickLogin()
    //{

    //    Social.localUser.Authenticate((bool success) => {

    //        if (success)
    //        {
    //            var serverAuthCode = PlayGamesPlatform.Instance.GetServerAuthCode();
    //            Debug.Log("Server Auth Code: " + serverAuthCode);

    //            PlayFabClientAPI.LoginWithGoogleAccount(new LoginWithGoogleAccountRequest()
    //            {
    //                TitleId = PlayFabSettings.TitleId,
    //                ServerAuthCode = serverAuthCode,
    //                CreateAccount = true
    //            }, (result) =>
    //            {
    //                User_ID = result.PlayFabId;
    //                SceneManager.LoadScene("LobbyScene");

    //            }, (error) =>
    //            {
    //                Debug.Log(error);
    //                return;
    //            }
    //            );
    //        }
    //        else
    //        {
    //            Debug.Log("Login Failed!");
    //        }

    //    });

    //}



}