using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private MazeBuilder mazeBuilder;

    void Start()
    {
        Maze maze = new Maze(gameData);

        mazeBuilder.Build25TestTile(maze);
    }

    void Update()
    {
        
    }
}
