using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameMng�� ���� Mng1�� �ν��Ͻ��� ������ Ŭ����
public class TestCall : MonoBehaviour
{
    void Start()
    {
        //GameMng.GetInstance().GetMng<Mng1>().CallMng();
        if (SceneManager.GetActiveScene().name =="Title")
            SceneManager.LoadScene("Lobby");
    }
    
}
