using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMng_2
{
    static GameObject gameObject;
    private static GameMng_2 instance;
    public static GameMng_2 GetInstance()
    {
        if(instance==null)
        {
            instance = new GameMng_2();
        }
        return instance;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void GamePause()
    {
        Debug.Log($"{GetType()}: GamePause()");
        gameObject = new GameObject();
        Debug.Log(gameObject);
        gameObject.transform.position = Vector3.zero;
    }

    public void GameResult()
    {
        
    }
}
