using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3x3Arena : Arena
{
    private readonly Vector3 NORTH_WALL_ROTATE = new Vector3(0.0f, 0.0f, 0.0f);
    private readonly Vector3 SOUTH_WALL_ROTATE = new Vector3(0.0f, 180.0f, 0.0f);
    private readonly Vector3 EAST_WALL_ROTATE = new Vector3(0.0f, 90.0f, 0.0f);
    private readonly Vector3 WEST_WALL_ROTATE = new Vector3(0.0f, -90.0f, 0.0f);

    private Vector3 centerPoint;

    public Room3x3Arena(GameData gameData) : base(gameData)
    {

    }

    public override void Render(MazeCell mazeCell, Vector3 center)
    {
        CreateFloor(mazeCell, center);
        CreateSides(mazeCell, center);
    }

    public override Vector3 GetCenterPoint()
    {
        return (centerPoint);
    }

    public override bool IsStartingArena()
    {
        return (false);
    }

    public override RuneCntrl GetRuneCntrl()
    {
        return (null);
    }

    private void CreateFloor(MazeCell mazeCell, Vector3 center)
    {
        CreateTheFloor(mazeCell, center);
    }

    private void CreateSides(MazeCell mazeCell, Vector3 center)
    {
        float distance = 1 * gameData.tileSize + gameData.tileSize / 2.0f;

        Transform parent = mazeCell.Parent.transform;

        int level = mazeCell.Level;

        centerPoint = center;

        CreateSide(mazeCell.IsNorth(), center + new Vector3(0.0f, center.y, distance), NORTH_WALL_ROTATE, parent, level);
        CreateSide(mazeCell.IsSouth(), center + new Vector3(0.0f, center.y, -distance), SOUTH_WALL_ROTATE, parent, level);
        CreateSide(mazeCell.IsEast(), center + new Vector3(distance, center.y, 0.0f), EAST_WALL_ROTATE, parent, level);
        CreateSide(mazeCell.IsWest(), center + new Vector3(-distance, center.y, 0.0f), WEST_WALL_ROTATE, parent, level);
    }

    private void CreateTheFloor(MazeCell mazeCell, Vector3 center)
    {
        Vector3 position = new Vector3();

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                position.x = center.x + x * gameData.tileSize;
                position.y = center.y;
                position.z = center.z + z * gameData.tileSize; 

                GameObject go = CreateTile(x, z, position);
                go.transform.parent = mazeCell.Parent.transform;
            }
        }
    }

    private void CreateSide(bool hasPassage, Vector3 position, Vector3 rotation, Transform parent, int level)
    {
        GameObject passage = null;
        GameObject archway = null;

        if (hasPassage)
        {
            archway = gameData.archwayPreFab;
            passage = Framework.PickFromList(gameData.tileOffSetPreFab);
        } else {
            passage = Framework.PickFromList(gameData.railingPreFab);
        }

        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.wallFramework).
            Assemble(gameData.railingPreFab, "Slab02", 180.0f).
            Assemble(gameData.halfWallPreFab, "Slab02", 0.0f).

            Assemble(passage, "Slab03", 0.0f).
            Assemble(archway, "Slab03", 0.0f).
            Assemble(gameData.halfWallPreFab, "Slab03", 0.0f).

            Assemble(gameData.railingPreFab, "Slab04", 180.0f).
            Assemble(gameData.halfWallPreFab, "Slab04", 0.0f).

            Assemble(gameData.pillarPreFab, "Pillar3", 0.0f).
            Assemble(gameData.pillarPreFab, "Pillar4", 0.0f).
            Position(position).
            Parent(parent).
            Rotate(rotation).
            Build();

        for (int l = 0; l < level-1; l++)
        {
            if (l == 0)
            {
                go = framework.
                    Blueprint(gameData.wallFramework).
                    Assemble(gameData.structurePreFab, "Slab02", 0.0f).
                    Assemble(gameData.structurePreFab, "Slab03", 0.0f).
                    Assemble(gameData.structurePreFab, "Slab04", 0.0f).
                    Position(position - new Vector3(0.0f, l * 5.0f + 2.5f, 0.0f)).
                    Parent(parent).
                    Rotate(rotation).
                    Build();
            }
            else
            {
                go = framework.
                    Blueprint(gameData.wallFramework).
                    Assemble(gameData.wallPreFab, "Slab02", 0.0f).
                    Assemble(gameData.wallPreFab, "Slab03", 0.0f).
                    Assemble(gameData.wallPreFab, "Slab04", 0.0f).
                    Position(position - new Vector3(0.0f, l * 5.0f + 2.5f, 0.0f)).
                    Parent(parent).
                    Rotate(rotation).
                    Build();
            }
        }
    }

    private GameObject CreateTile(int x, int z, Vector3 position)
    {
        GameObject preFab = Framework.PickFromList(gameData.tilePreFab);

        return(Framework.CreateObject(preFab, position, Framework.Rotate90Degree()));
    }
}
