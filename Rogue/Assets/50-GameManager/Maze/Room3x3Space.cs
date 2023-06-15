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
        /*Vector3 position = new Vector3();

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                position.x = center.x + x * 5.0f;
                position.y = center.y;
                position.z = center.z + z * 5.0f; ;

                GameObject go = CreateTile(x, z, position);
                go.transform.parent = mazeCell.Parent.transform;
            }
        } */

        CreateTheFloor(mazeCell, center);

        //CreatePassages(mazeCell, center);
    }

    public override void CreateSides(MazeCell mazeCell, Vector3 center)
    {
        float distance = 1 * 5 + 5.0f / 2.0f;

        Transform parent = mazeCell.Parent.transform;

        CreateSide(mazeCell.IsNorth(), center + new Vector3(0.0f, center.y, distance), NORTH_WALL_ROTATE, parent, mazeCell.IsNorthDown());
        CreateSide(mazeCell.IsSouth(), center + new Vector3(0.0f, center.y, -distance), SOUTH_WALL_ROTATE, parent, mazeCell.IsSouthDown());
        CreateSide(mazeCell.IsEast(), center + new Vector3(distance, center.y, 0.0f), EAST_WALL_ROTATE, parent, mazeCell.IsEastDown());
        CreateSide(mazeCell.IsWest(), center + new Vector3(-distance, center.y, 0.0f), WEST_WALL_ROTATE, parent, mazeCell.IsWestDown());
    }

    private void CreateTheFloor(MazeCell mazeCell, Vector3 center)
    {
        Vector3 position = new Vector3();

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                position.x = center.x + x * 5.0f;
                position.y = center.y;
                position.z = center.z + z * 5.0f; ;

                GameObject go = CreateCenterTile(x, z, position);
                go.transform.parent = mazeCell.Parent.transform;
            }
        }
    }

    private void CreateSide(bool hasPassage, Vector3 position, Vector3 rotation, Transform parent, bool createStairs)
    {
        //GameObject passage = (hasPassage) ? gameData.archwayPreFab : gameData.simpleRailingPreFab;

        //GameObject stairs = (createStairs) ? gameData.stairsSimplePreFab : Framework.PickFromList(gameData.tileOffSetPreFab);
        //
        GameObject passage;

        if (hasPassage)
        {
            if (createStairs)
            {
                passage = gameData.stairsSimplePreFab;
            } else {
                passage = Framework.PickFromList(gameData.tileOffSetPreFab);
            }
        } else {
            passage = gameData.simpleRailingPreFab;
        }

        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.wallFramework).
            Assemble(gameData.simpleRailingPreFab, "Slab02", 180.0f).
            Assemble(passage, "Slab03", 0.0f).
            Assemble(gameData.simpleRailingPreFab, "Slab04", 180.0f).
            Position(position).
            Parent(parent).
            Rotate(rotation).
            Build();
    }

    private GameObject CreateCenterTile(int x, int z, Vector3 position)
    {
        GameObject preFab;

        if ((x == 0) && (z == 0))
        {
            preFab = Framework.PickFromList(gameData.runePreFab);
        }
        else
        {
            preFab = Framework.PickFromList(gameData.tilePreFab);
        }

        return(Framework.CreateObject(preFab, position, Framework.Rotate90Degree()));
    }
}
