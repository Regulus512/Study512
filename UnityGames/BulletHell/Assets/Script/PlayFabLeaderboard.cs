using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabLeaderboard : MonoBehaviour
{
    public PFGoogleSignInUnity google;
    private void OnEnable()
    {
        //print("ranking enable()");
        google.RequestLeaderboard();
    }
}
