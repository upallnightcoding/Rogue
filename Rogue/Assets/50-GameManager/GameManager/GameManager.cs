using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private MazeBuilder mazeBuilder;
    [SerializeField] private UICntrl uiCntrl;
    [SerializeField] private PlayerCntrl playerCntrl;

    public static GameManager Instance { get; private set; }

    private GameState gameState = GameState.GAME_PLAY;

    private void Awake()
    {
        if ((Instance != null) && (Instance != this))
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        uiCntrl.SelectStartPanel();
    }

    public void StartGame()
    {
        uiCntrl.SelectGamePanel();

        Maze maze = new Maze(gameData);

        mazeBuilder.BuildWorld(maze);

        playerCntrl.StartPlay();
    }

    public void SettingGame()
    {

    }

    public void QuitGame()
    {
        uiCntrl.QuitGamePanel();
    }

    public void SelectRune(int runTileIndex)
    {
        uiCntrl.SelectRune(runTileIndex);
    }

    public void AddGemCount(int count)
    {
        uiCntrl.AddGemCount(count);
    }

    private enum GameState 
    {
        OPEN_SCREEN,
        GAME_PLAY,
        QUIT
    }
}
