using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Test Class (�Ϲ�ȭ �Լ��� ȣ���� Ŭ����)
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
            // �� ��ȯ �� ����
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
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
