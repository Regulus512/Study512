using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

struct RankData
{
    public int score;
    public int timer;
}

public class DataController : MonoBehaviour
{
    List<RankData> rankList;
    
    [SerializeField] TextMeshProUGUI[] scoreUIs, timerUIs;

    private void Awake()
    {
        LoadRank();
        ShowRank();
    }

    public void LoadRank()
    {
        rankList = new List<RankData>();
        string data;
        // 
        if (PlayerPrefs.HasKey("rankData"))
        {
            data = PlayerPrefs.GetString("rankData");
        }
        else
        {
            data = "0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0";
            PlayerPrefs.SetString("rankData", data);
        }
        var list = data.Split(" ");
        for (int i = 0; i < 10; i++)
        {
            var items = list[i].Split(",").Select(o => int.Parse(o));
            RankData rankData;
            rankData.score = items.ElementAt(0);
            rankData.timer = items.ElementAt(1);

            rankList.Add(rankData);
        }
    }

    public void SaveRank(int _curScore, int _curTimer)
    {
        // 로컬 랭크는 항상 내림차순인 데이터이기 때문에 정렬 알고리즘은 필요없음
        int id = -1;
        int max = rankList.Count;

        List<int> sameScore = new List<int>();
        for (int i = 0; i < max; i++)
        {
            if(_curScore == rankList[i].score)
            {
                sameScore.Add(i);
            }
            if(_curScore > rankList[i].score)
            {
                id = i;
                sameScore.Add(i);
                break;
            }
        }
        if (id == -1) return;
        
        RankData data;
        for (int i = max - 1; i > id; i--)
        {
            data = rankList[i - 1];
            rankList[i] = data;
        }

        data.score = _curScore;
        data.timer = _curTimer;
        rankList[id] = data;

        string save = "";
        for (int i = 0; i < max; i++)
        {
            save += rankList[i].score + "," + rankList[i].timer + " ";
        }
        PlayerPrefs.SetString("rankData", save);



        if (sameScore.Count < 2) return;
        id = -1;
        foreach (int i in sameScore)
        {
            if (_curTimer < rankList[i].timer)
            {
                id = i;
                print($"[data] smaller than {id}");
                break;
            }
                
        }
        if (id == -1) return;
        for (int i = sameScore[sameScore.Count-1]; i > id ; i--)
        {
            print($"[data] {i-1} to {i}");
            data = rankList[i - 1];
            rankList[i] = data;
        }
        
        
        data.score = _curScore;
        data.timer = _curTimer;
        rankList[id] = data;

        save = "";
        for (int i = 0; i < max; i++)
        {
            save += rankList[i].score + "," + rankList[i].timer + " ";
        }
        PlayerPrefs.SetString("rankData", save);

    }

    // rank ui에 적용
    public void ShowRank()
    {
        for (int i = 0; i < 10; i++)
        {
            RankData data = rankList[i];
            scoreUIs[i].text = data.score.ToString();
            timerUIs[i].text = data.timer.ToString();
        }
        //PrintRank();
    }

    public void PrintRank()
    {
        string str = "Rank: ";
        foreach(var data in rankList)
        {
            str += data.score + "," + data.timer+" ";
        }
        print(str);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.GetInstance().GameOver();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            print("Clear()");
            PlayerPrefs.SetString("rankData", "0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0 0,0");
            LoadRank();
            ShowRank();
        }
    }
}
