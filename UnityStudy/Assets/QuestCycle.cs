using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QuestCycle : MonoBehaviour
{
    private int index = 0;

    private void Update()
    {
        index += 1;
        Constant.index += 1;
        print(string.Format("Update. Local: {0}, Global: {1}", index, Constant.index));
    }
    private void LateUpdate()
    {
        index -= 1;
        Constant.index -= 1;
        print(string.Format("LateUpdate. Local: {0}, Global: {1}", index, Constant.index));
    }
}
