using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QuestCycle : MonoBehaviour
{
    private int local = 0;

    private void Update()
    {
        local++;
        Global.global++;
        print(string.Format("Update. Local: {0}, Global: {1}", local, Global.global));
    }
    private void LateUpdate()
    {
        local--;
        Global.global--;
        print(string.Format("Update. Local: {0}, Global: {1}", local, Global.global));
    }
}
