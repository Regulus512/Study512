using UnityEngine;

public class MngScene : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = -1;
    }
    private void Update()
    {
        print("Update1");
        print("Update2");
        print("Update3");
    }
}
