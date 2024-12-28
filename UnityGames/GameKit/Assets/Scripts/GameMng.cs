using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test Class (�Ϲ�ȭ �Լ��� ȣ���� Ŭ����)
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
            // �� ��ȯ �� ����
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� GameMgr�� ������ ���� �ִ�.
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
