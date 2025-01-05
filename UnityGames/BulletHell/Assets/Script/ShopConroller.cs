using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopConroller : MonoBehaviour
{
    public void Close()
    {
        SceneManager.LoadScene(0);
    }
}
