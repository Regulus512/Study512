using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test Class (일반화 함수 호출로 불러올 클래스)
public class Mng1 : MonoBehaviour
{
    public void CallMng()
    {
        print(gameObject.name);
    }
}
