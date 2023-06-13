using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3x3Space : Space
{
    private readonly Vector3 NORTH_PASS = new Vector3(0.0f, 0.0f, 10.0f);
    private readonly Vector3 SOUTH_PASS = new Vector3(0.0f, 0.0f, -10.0f);
    private readonly Vector3 EAST_PASS = new Vector3(10.0f, 0.0f, 0.0f);
    private readonly Vector3 WEST_PASS = new Vector3(-10.0f, 0.0f, 0.0f);

    private readonly Vector3 NORTH_WALL_ROTATE = new Vector3(0.0f, 0.0f, 0.0f);
    private readonly Vector3 SOUTH_WALL_ROTATE = new Vector3(0.0f, 180.0f, 0.0f);
    private readonly Vector3 EAST_WALL_ROTATE = new Vector3(0.0f, 90.0f, 0.0f);
    private readonly Vector3 WEST_WALL_ROTATE = new Vector3(0.0f, -90.0f, 0.0f);

    public Room3x3Space(GameData gameData) : base(gameData)
    {

    }

    public override void CreateFloor(MazeCell mazeCell, Vector3 center)
    {
        Vector3 position = new Vector3();

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                position.x = center.x + x * 5.0f;
                position.y = center.y;
                position.z = center.z + z * 5.0f; ;

                CreateTile(x, z, position);
            }
        }

        CreatePassages(mazeCell, center);
    }

    public override void CreateWalls(MazeCell mazeCell, Vector3 center)
    {
        float distance = 1 * 5 + 5.0f / 2.0f;

        CreateWall(mazeCell.IsNorth(), center + new Vector3(0.0f, center.y, distance), NORTH_WALL_ROTATE);
        CreateWall(mazeCell.IsSouth(), center + new Vector3(0.0f, center.y, -distance), SOUTH_WALL_ROTATE);
        CreateWall(mazeCell.IsEast(), center + new Vector3(distance, center.y, 0.0f), EAST_WALL_ROTATE);
        CreateWall(mazeCell.IsWest(), center + new Vector3(-distance, center.y, 0.0f), WEST_WALL_ROTATE);
    }

    private void CreateWall(bool hasPassage, Vector3 position, Vector3 rotation)
    {
        GameObject passage = (hasPassage) ? gameData.archwayPreFab : Framework.PickFromList(gameData.wallsPreFab);

        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.wallFramework).
            Assemble(gameData.wallsPreFab, "Slab02", 180.0f).
            Assemble(passage, "Slab03", 180.0f).
            Assemble(gameData.wallsPreFab, "Slab04", 180.0f).
            Position(position).
            Rotate(rotation).
            Build();
    }

    private void CreateTile(int x, int z, Vector3 position)
    {
        GameObject preFab = null;

        if ((x == 0) && (z == 0))
        {
            preFab = Framework.PickFromList(gameData.runePreFab);
        }
        else
        {
            preFab = Framework.PickFromList(gameData.tilePreFab);
        }

        Framework.CreateObject(preFab, position, Framework.Rotate90Degree());
    }

    private void CreatePassages(MazeCell mazeCell, Vector3 center)
    {
        GameObject preFab = Framework.PickFromList(gameData.tilePreFab);

        if (mazeCell.IsNorth())
        {
            Framework.CreateObject(preFab, center + NORTH_PASS, Framework.Rotate90Degree());
        }

        if (mazeCell.IsSouth())
        {
            Framework.CreateObject(preFab, center + SOUTH_PASS, Framework.Rotate90Degree());
        }

        if (mazeCell.IsEast())
        {
            Framework.CreateObject(preFab, center + EAST_PASS, Framework.Rotate90Degree());
        }

        if (mazeCell.IsWest())
        {
            Framework.CreateObject(preFab, center + WEST_PASS, Framework.Rotate90Degree());
        }
    }
}
