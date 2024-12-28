using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test Class (일반화 함수를 호출할 클래스)
public class GameMng : MonoBehaviour
{
    private static GameMng instance;
    public static GameMng GetInstance() { return (instance == null) ? null : instance; }
    public GameObject[] MngObjs;

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

    public T GetMng<T>()
    {
        foreach(var Mng in MngObjs)
        {
            var mngComponent = Mng.GetComponent<T>();
            if (mngComponent != null)
                return mngComponent;
        }
        return default;
    }

}
