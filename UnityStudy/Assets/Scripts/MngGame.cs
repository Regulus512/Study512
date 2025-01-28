using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngGame : MonoBehaviour
{
    public Hole firstHole;
    void Start()
    {
        firstHole.PlayAnimation();
    }
    private void Update()
    {
        print("main routine");
    }
}
