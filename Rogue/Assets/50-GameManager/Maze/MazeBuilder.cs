using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    public void Build9TestTile(Maze maze)
    {
        float distance = 20.0f;
        GameObject go = null;

        for (int col = 0; col < maze.Width; col++)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                Vector3 position = new Vector3(col * distance, 0.0f, row * distance);

                CreateCellWithRune(position);

                MazeCell cell = maze.GetMazeCell(col, row);

                if (cell.IsNorth())
                {
                    go = Instantiate(gameData.testTilePrefab, new Vector3(position.x, position.y, position.z + 10.0f), Quaternion.identity);
                }

                if (cell.IsEast())
                {
                    go = Instantiate(gameData.testTilePrefab, new Vector3(position.x + 10.0f, position.y, position.z), Quaternion.identity);
                }
            }
        }
    }

    public GameObject CreateCellWithRune(Vector3 position)
    {
        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.tileFramwork).
            Assemble(gameData.tilePreFab, "North", TurnGameObject()).
            Assemble(gameData.tilePreFab, "South", TurnGameObject()).
            Assemble(gameData.tilePreFab, "East", TurnGameObject()).
            Assemble(gameData.tilePreFab, "West", TurnGameObject()).
            Assemble(gameData.tilePreFab, "NorthEast", TurnGameObject()).
            Assemble(gameData.tilePreFab, "NorthWest", TurnGameObject()).
            Assemble(gameData.tilePreFab, "SouthEast", TurnGameObject()).
            Assemble(gameData.tilePreFab, "SouthWest", TurnGameObject()).
            Assemble(gameData.runePreFab, "Center", TurnGameObject()).
            Assemble(gameData.wallsPreFab, "EastWall01", -90.0f).
            Assemble(gameData.wallsPreFab, "EastWall02", -90.0f).
            Assemble(gameData.wallsPreFab, "EastWall03", -90.0f).
            Assemble(gameData.wallsPreFab, "WestWall01", 90.0f).
            Assemble(gameData.wallsPreFab, "WestWall02", 90.0f).
            Assemble(gameData.wallsPreFab, "WestWall03", 90.0f).
            Assemble(gameData.wallsPreFab, "NorthWall01", 180.0f).
            Assemble(gameData.wallsPreFab, "NorthWall02", 180.0f).
            Assemble(gameData.wallsPreFab, "NorthWall03", 180.0f).
            Position(position).
            Build();

        return (go);
    }

    public GameObject CreateCellWithOutRune(Vector3 position)
    {
        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.tileFramwork).
            Assemble(gameData.tilePreFab, "North", TurnGameObject()).
            Assemble(gameData.tilePreFab, "South", TurnGameObject()).
            Assemble(gameData.tilePreFab, "East", TurnGameObject()).
            Assemble(gameData.tilePreFab, "West", TurnGameObject()).
            Assemble(gameData.tilePreFab, "NorthEast", TurnGameObject()).
            Assemble(gameData.tilePreFab, "NorthWest", TurnGameObject()).
            Assemble(gameData.tilePreFab, "SouthEast", TurnGameObject()).
            Assemble(gameData.tilePreFab, "SouthWest", TurnGameObject()).
            Assemble(gameData.tilePreFab, "Center", TurnGameObject()).
            Position(position).
            Build();

        return (go);
    }

    private float TurnGameObject()
    {
        return (Random.Range(0, 4) * 90.0f);
    }
}
