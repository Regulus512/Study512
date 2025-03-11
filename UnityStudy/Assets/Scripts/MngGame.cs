using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngGame : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        Hole start = GameObject.Find("Hole 1").GetComponent<Hole>();
        StartCoroutine(start.animation());
    }
}
