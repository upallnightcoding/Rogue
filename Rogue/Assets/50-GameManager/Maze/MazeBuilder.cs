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

    public void Build9TestTile(Maze maze)
    {
        float distance = 20.0f;
        GameObject go = null;

        for (int col = 0; col < maze.Width; col++)
        {
            for (int row = 0; row < maze.Height; row++)
            {
                Vector3 position = new Vector3(col * distance, 0.0f, row * distance);

                MazeCell cell = maze.GetMazeCell(col, row);

                CreateCellWithRune(cell, position);

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

    public GameObject CreateCellWithRune(MazeCell cell, Vector3 position)
    {
        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.tileFramwork).
            Assemble(new ArrayOfObjectsFw(gameData.tilePreFab, nsew, TurnGameObject())).
            Assemble(gameData.runePreFab, "Center", TurnGameObject()).

            Assemble(new ArrayOfObjectsFw(gameData.wallsPreFab, eastWall, -90.0f)).
            Assemble(new ChoiceOfObjectsFw(gameData.archwayPreFab, gameData.wallsPreFab[0], cell.IsEast(), "EastWall02", -90.0f)).

            Assemble(new ArrayOfObjectsFw(gameData.wallsPreFab, westWall, 90.0f)).
            Assemble(new ChoiceOfObjectsFw(gameData.archwayPreFab, gameData.wallsPreFab[0], cell.IsWest(), "WestWall02", 90.0f)).

            Assemble(new ArrayOfObjectsFw(gameData.wallsPreFab, northWall, 180.0f)).
            Assemble(new ChoiceOfObjectsFw(gameData.archwayPreFab, gameData.wallsPreFab[0], cell.IsNorth(), "NorthWall02", 180.0f)).

            Assemble(new ArrayOfObjectsFw(gameData.wallsPreFab, southWall, 0.0f)).
            Assemble(new ChoiceOfObjectsFw(gameData.archwayPreFab, gameData.wallsPreFab[0], cell.IsSouth(), "SouthWall02", 0.0f)).

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
