using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    public void BuildWorld(Maze maze)
    {
        float distance = 30.0f;
        float pathPos = 15.0f;
        GameObject go = null;

        Space space5x5 = new Room5x5Space(gameData);
        Space space3x3 = new Room3x3Space(gameData);

        for (int col = 0; col < maze.Width; col++)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                Vector3 center = new Vector3(col * distance, 0.0f, row * distance);

                MazeCell mazeCell = maze.GetMazeCell(col, row);

                Space space = Random.Range(0, 2) == 0 ? space5x5 : space3x3;

                space.CreateFloor(mazeCell, center);
                space.CreateSides(mazeCell, center);

                if (mazeCell.IsNorth())
                {
                    Framework.CreateObject(gameData.tilePreFab, new Vector3(center.x, center.y, center.z + pathPos), 0.0f);
                }

                if (mazeCell.IsEast())
                {
                    Framework.CreateObject(gameData.tilePreFab, new Vector3(center.x + pathPos, center.y, center.z), 0.0f);
                }

            }
        }

        CalculateLevels(maze);

        AdjustPositionByLevel(maze);
    }

    private void AdjustPositionByLevel(Maze maze)
    {
        for (int col = 0; col < maze.Width; col++)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                MazeCell mazeCell = maze.GetMazeCell(col, row);

                Vector3 position = mazeCell.Parent.transform.position;

                mazeCell.Parent.transform.position =
                    new Vector3(position.x, position.y + mazeCell.Level * 2.5f, position.z);
            }
        }
    }

    private void CalculateLevels(Maze maze)
    {
        List<MazeCell> cellList = new List<MazeCell>();
        cellList.Add(maze.GetMazeCell(0, 0));

        int level = 3;

        CalculateLevels(maze, cellList, level);
    }

    private void CalculateLevels(Maze maze, List<MazeCell> mazeCellList, int level)
    {
        if ((level > 0) && (mazeCellList.Count > 0))
        {
            List<MazeCell> nextLevel = new List<MazeCell>();

            foreach (MazeCell mazeCell in mazeCellList)
            {
                mazeCell.Level = level;

                List<MazeCell> neighbors = mazeCell.GetNeighborList();

                foreach (MazeCell neighbor in neighbors)
                {
                    if (neighbor.Level == 0)
                    {
                        nextLevel.Add(neighbor);
                    }
                }
            }

            CalculateLevels(maze, nextLevel, level - 1);
        }
    }
}
