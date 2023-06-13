using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    public void Build5x5Room(Maze maze)
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
                space.CreateWalls(mazeCell, center);

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
    }
}
