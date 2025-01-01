using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    public void OnClick()
    {
        GameMng.GetInstance().GamePause();
        GameMng_2.GetInstance().GamePause();
    }
}
