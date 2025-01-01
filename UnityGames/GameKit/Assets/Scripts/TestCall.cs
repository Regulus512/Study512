using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameMng를 통해 Mng1의 인스턴스를 참조할 클래스
public class TestCall : MonoBehaviour
{
    void Start()
    {
        GameMng.GetInstance().GetMng<Mng1>().CallMng();
        GameMng_2.GetInstance().GameStart();
    }
    
}
