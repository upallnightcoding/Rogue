using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private MazeBuilder mazeBuilder;
    [SerializeField] private UICntrl uiCntrl;
    [SerializeField] private PlayerCntrl playerCntrl;
    [SerializeField] private ArenaMgr arenaMgr;

    public static GameManager Instance { get; private set; }

    private GameState gameState = GameState.GAME_PLAY;

    private int runTileIndex = 0;

    private int totalGemCount = 0;

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

        //arenaMgr.TurnOn();
    }

    public void SettingGame()
    {

    }

    public void QuitGame()
    {
        uiCntrl.QuitGamePanel();
    }

    public void AddGem(int count)
    {
        totalGemCount += count; 

        if ((runTileIndex < gameData.runePoints.Length) && (totalGemCount >= gameData.runePoints[runTileIndex]))
        {
            uiCntrl.SelectRune(runTileIndex);
            arenaMgr.TurnOn(runTileIndex);
            runTileIndex++;
        }

        uiCntrl.DisplayGem(totalGemCount);
    }

    private enum GameState 
    {
        OPEN_SCREEN,
        GAME_PLAY,
        QUIT
    }
}
