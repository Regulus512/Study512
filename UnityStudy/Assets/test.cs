using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        print("test .Update");
    }
    private void LateUpdate()
    {
        print("test .LateUpdate");
    }
}