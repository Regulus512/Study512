using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Test Class (일반화 함수를 호출할 클래스)
public class GameMng : MonoBehaviour
{
    private static GameMng instance;
    public static GameMng GetInstance() { return (instance == null) ? null : instance; }
    public List<GameObject> MngObjs = new List<GameObject>();

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            // 씬 전환 시 유지
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            Destroy(this.gameObject);
        }
        
    }
    
    public void GameStart()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void GamePause()
    {
        print($"{GetType()}:GamePause()");
    }

    public void GameResult()
    {
        SceneManager.LoadScene("GameResult");
    }
    

    public T GetMng<T>()
    {
        foreach(var Mng in MngObjs)
        {
            if (Mng == null) continue;
            var mngComponent = Mng.GetComponent<T>();
            if (mngComponent != null)
                return mngComponent;
        }
        return default;
    }

}
