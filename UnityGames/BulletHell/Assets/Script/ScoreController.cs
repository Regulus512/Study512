using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyUI;
    int currency = 0;
    public void AddMoney()
    {
        var request = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "KW", Amount = 50 };
        PlayFabClientAPI.AddUserVirtualCurrency(request, (result) =>
        {
            //currency controller를 따로 둔다
            //0원을 넣으면 돈을 안넣고도 result를 불러올 수 있다
            currency = result.Balance;
            print("돈 얻기 성공! 현재 돈 : " + result.Balance);
            
            currencyUI.text = result.Balance.ToString();
        }, (error) => print(error.GenerateErrorReport()));
    }

    [SerializeField] DataController dataController;
    [SerializeField]
    TextMeshProUGUI score_over, score_clear;
    int curScore = 0;

    [SerializeField]
    TextMeshProUGUI timer_over, timer_clear;
    float curTimer = 0;
    public int GetTimer() { return (int)curTimer; }

    public int GetScore() { return curScore; }

    public void AddScore(int _input)
    {
        curScore += _input;
    }
    
    public void ShowResult()
    {
        int _timer = (int)curTimer;
        score_over.text = "Score: " + curScore;
        score_clear.text = "Score: " + curScore;
        timer_over.text = "Timer: " + _timer;
        timer_clear.text = "Timer: " + _timer;
        if(curScore > 0)
            dataController.SaveRank(curScore, _timer);
        dataController.ShowRank();
        
    }
    public void GameStart()
    {
        curScore = 0;
        curTimer = 0;
        isTimer = true;
    }

    bool isTimer = false;
    public void SetTimer(bool _input)
    {
        isTimer = _input;
    }
    // Update is called once per frame
    void Update()
    {
        if(isTimer)
        {
            curTimer += Time.deltaTime;
            //print(curTimer);
        }
        
    }
}
