using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
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
