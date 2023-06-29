using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private MazeBuilder mazeBuilder;
    [SerializeField] private UICntrl uiCntrl;

    public static GameManager Instance { get; private set; }

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
        Maze maze = new Maze(gameData);

        mazeBuilder.BuildWorld(maze);
    }

    public void AddGemCount(int count)
    {
        uiCntrl.AddGemCount(count);
    }
}
