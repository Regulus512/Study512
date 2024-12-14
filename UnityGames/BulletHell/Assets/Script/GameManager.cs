using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GAMESTATE
{
    LOBBY, INGAME, GAMEOVER
}

public class GameManager : MonoBehaviour
{
    [SerializeField] InputController inputController = null;
    [SerializeField] PlayerController playerController = null;
    [SerializeField] BossController bossController = null;
    [SerializeField] ScoreController scoreController;

    [SerializeField] GameObject lobby_ui, gameOver_ui, gameClear_ui;

    GAMESTATE gameState = GAMESTATE.LOBBY;

    private static GameManager instance;
    public static GameManager GetInstance()
    {
        if (instance != null)
        {
            return instance;
        }
        Debug.Log("[Error] There is no GameManager Instance");
        return null;
    }

    void Awake()
    {
        instance = this;
        gameOver_ui.SetActive(false);
    }
    

    // 게임 시작 버튼 클릭(로비)
    public void GameStart()
    {
        inputController.GameStart();
        playerController.GameStart();
        bossController.GameStart();
        scoreController.GameStart();

        gameState = GAMESTATE.INGAME;
        Debug.Log("[GM] GameStart");
    }

    

    // 게임 오버(인게임)
    // 플레이어 or 보스 체력 0
    public void GameOver()
    {
        if (gameState != GAMESTATE.INGAME)
        {
            return;
        }
        if (gameOver_ui)
        {
            gameOver_ui.SetActive(true);
        }
        inputController.GameOver();
        playerController.GameOver();
        bossController.GameOver();
        BulletPool.instance.GameOver();
        scoreController.SetTimer(false);
        scoreController.ShowResult();
        gameState = GAMESTATE.GAMEOVER;
        
        Debug.Log("[GM] GameOver");
    }

    public void GameClear()
    {
        if (gameState != GAMESTATE.INGAME)
        {
            return;
        }
        if (gameClear_ui)
        {
            gameClear_ui.SetActive(true);
        }
        gameState = GAMESTATE.GAMEOVER;
        scoreController.ShowResult();
        playerController.GameOver();
        bossController.GameOver();
        inputController.GameOver();
        Debug.Log("[GM] GameClear");
    }

    // 게임 재시작 버튼 클릭(게임오버)
    public void Retry()
    {
        GameStart();
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
