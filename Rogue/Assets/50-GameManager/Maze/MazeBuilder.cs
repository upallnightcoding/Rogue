using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    List<string> nsew = new List<string> {
        "North", "South", "East", "West", "NorthEast", "NorthWest", "SouthEast", "SouthWest"
    };

    List<string> eastWall = new List<string> {
        "EastWall01", "EastWall03"
    };

    List<string> westWall = new List<string> {
        "WestWall01", "WestWall03"
    };

    List<string> northWall = new List<string> {
            "NorthWall01", "NorthWall03"
        };

    List<string> southWall = new List<string> {
            "SouthWall01", "SouthWall03"
        };

    public void Build25TestTile(Maze maze)
    {
        float distance = 30.0f;
        float pathPos = 15.0f;
        GameObject go = null;

        for (int col = 0; col < maze.Width; col++)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                Vector3 position = new Vector3(col * distance, 0.0f, row * distance);

                MazeCell cell = maze.GetMazeCell(col, row);

                Create25CellWithRune(cell, position);

                if (cell.IsNorth())
                {
                    go = Instantiate(gameData.testTilePrefab, new Vector3(position.x, position.y, position.z + pathPos), Quaternion.identity);
                }

                if (cell.IsEast())
                {
                    go = Instantiate(gameData.testTilePrefab, new Vector3(position.x + pathPos, position.y, position.z), Quaternion.identity);
                }

            }
        }
    }

    private void Create25CellWithRune(MazeCell cell, Vector3 origin)
    {
        Vector3 position = new Vector3();

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -2; z <= 2; z++)
            {
                position.x = origin.x + x * 5.0f;
                position.y = origin.y;
                position.z = origin.z + z * 5.0f; ;

                int selection = Random.Range(0, gameData.tilePreFab.Length);

                Instantiate(gameData.tilePreFab[selection], position, Quaternion.identity);


            }
        }
    }

    private float TurnGameObject()
    {
        return (Random.Range(0, 4) * 90.0f);
    }
}
