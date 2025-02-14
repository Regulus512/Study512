using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngGame : MonoBehaviour
{
    public Hole firstHole;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        StartCoroutine(firstHole.animation());
    }
}
