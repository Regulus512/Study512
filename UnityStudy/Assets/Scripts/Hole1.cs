using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole1 : MonoBehaviour
{
    public GameObject obj1 = null;
    public GameObject obj2 = null;
    public GameObject obj3 = null;

    void Start()
    {
        // find gameobject reference
        obj1 = GameObject.Find("Hole 1");
        obj2 = GameObject.FindWithTag("Player");
    }

}
