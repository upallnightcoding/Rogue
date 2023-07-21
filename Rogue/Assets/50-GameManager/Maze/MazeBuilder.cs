using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private ArenaMgr arenaMgr;

    public void BuildWorld(Maze maze)
    {
        arenaMgr.Initialize(gameData);

        CalculateLevels(maze);

        arenaMgr.CreateAllArenas();

        RenderWorld(maze);

        AdjustPositionByLevel(maze);
    }

    private void RenderWorld(Maze maze)
    {
        float distance = 30.0f;
        float pathPos = 15.0f;

        for (int col = 0; col < maze.Width; col++)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                Vector3 center = new Vector3(col * distance, 0.0f, row * distance);

                MazeCell mazeCell = maze.GetMazeCell(col, row);

                arenaMgr.Render(col, row, mazeCell, center);

                CreateAreaPaths(mazeCell, center, pathPos);
            }
        }

        //arenaMgr.TurnOn();
    }

    private void CreateAreaPaths(MazeCell mazeCell, Vector3 center, float pathPos)
    {
        if (mazeCell.IsNorth())
        {
            int level = mazeCell.GetNorthLower();
            Vector3 position = new Vector3(center.x, center.y + level * gameData.tileRise, center.z + pathPos);

            if (mazeCell.IsNorthEqual())
            {
                Framework.CreateObject(gameData.tilePreFab, position, 0.0f);
            } 
            else
            {
                float rotation = (mazeCell.IsNorthDown()) ? 0.0f : 180.0f;
                Framework.CreateObject(gameData.stairsSimplePreFab, position, rotation);
            }
        }

        if (mazeCell.IsEast())
        {
            int level = mazeCell.GetEastLower();
            Vector3 position = new Vector3(center.x + pathPos, center.y + level * gameData.tileRise, center.z);

            if (mazeCell.IsEastEqual())
            {
                Framework.CreateObject(gameData.tilePreFab, position, 0.0f);
            } 
            else
            {
                float rotation = (mazeCell.IsEastDown()) ? 90.0f : 270.0f;
                Framework.CreateObject(gameData.stairsSimplePreFab, position, rotation);
            }
        }
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
                    new Vector3(position.x, position.y + mazeCell.Level * gameData.tileRise, position.z);

                Arena arena = arenaMgr.GetArena(col, row);

                if (arena.IsStartingArena())
                {
                    gameData.playerStartingArena = 
                        arena.GetCenterPoint() + new Vector3(0.0f, 1.1f + mazeCell.Level * gameData.tileRise, 0.0f);
                }
            }
        }
    }

    private void CalculateLevels(Maze maze)
    {
        List<MazeCell> cellList = new List<MazeCell>();
        cellList.Add(maze.GetMazeCell(4, 4));

        int level = 7;

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
