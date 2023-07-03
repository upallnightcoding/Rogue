using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5x5Space : Arena
{
    private readonly Vector3 NORTH_WALL_ROTATE = new Vector3(0.0f, 0.0f, 0.0f);
    private readonly Vector3 SOUTH_WALL_ROTATE = new Vector3(0.0f, 180.0f, 0.0f);
    private readonly Vector3 EAST_WALL_ROTATE = new Vector3(0.0f, 90.0f, 0.0f);
    private readonly Vector3 WEST_WALL_ROTATE = new Vector3(0.0f, -90.0f, 0.0f);

    private GameObject runeTile = null;
    private GameObject middleTile = null;

    private Vector3 centerPoint;

    public Room5x5Space(GameData gameData) : base(gameData)
    {

    }

    public override bool IsStartingArena()
    {
        return (false);
    }

    public override RuneCntrl GetRuneCntrl()
    {
        return (null);
    }

    public override Vector3 GetCenterPoint()
    {
        return (centerPoint);
    }

    public override void Render(MazeCell mazeCell, Vector3 center)
    {
        centerPoint = center;

        CreateFloor(mazeCell, center);
        CreateSides(mazeCell, center);
    }

    public void CreateFloor(MazeCell mazeCell, Vector3 center)
    {
        Vector3 position = new Vector3();

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -2; z <= 2; z++)
            {
                position.x = center.x + x * gameData.tileSize;
                position.y = center.y;
                position.z = center.z + z * gameData.tileSize; 

                if ((x == 0) && (z == 0))
                {
                    Framework.CreateObject(gameData.statuePreFab, position, Framework.Rotate90Degree(), mazeCell.Parent);
                } 

                int selection = Random.Range(0, gameData.tilePreFab.Length);
                Framework.CreateObject(gameData.tilePreFab[selection], position, Framework.Rotate90Degree(), mazeCell.Parent);
            }
        }
    }

    public void CreateSides(MazeCell mazeCell, Vector3 center)
    {
        float distance = 2 * gameData.tileSize + gameData.tileSize / 2.0f;

        Transform parent = mazeCell.Parent.transform;

        int level = mazeCell.Level;

        CreateWall(mazeCell.IsNorth(), center + new Vector3(0.0f, center.y, distance), NORTH_WALL_ROTATE, parent, level);
        CreateWall(mazeCell.IsSouth(), center + new Vector3(0.0f, center.y, -distance), SOUTH_WALL_ROTATE, parent, level);
        CreateWall(mazeCell.IsEast(), center + new Vector3(distance, center.y, 0.0f), EAST_WALL_ROTATE, parent, level);
        CreateWall(mazeCell.IsWest(), center + new Vector3(-distance, center.y, 0.0f), WEST_WALL_ROTATE, parent, level);
    }

    private void CreateWall(bool hasPassage, Vector3 position, Vector3 rotation, Transform parent, int level)
    {
        GameObject passage = (hasPassage) ? gameData.archwayPreFab : Framework.PickFromList(gameData.railingPreFab);

        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.wallFramework).
            Assemble(gameData.railingPreFab, "Slab01", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab01", 0.0f).
            Assemble(gameData.railingPreFab, "Slab02", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab02", 0.0f).

            Assemble(passage, "Slab03", 180.0f).
            Assemble(gameData.halfWallPreFab, "Slab03", 0.0f).
            //Assemble(gameData.stairsSimplePreFab, "Slab03", 0.0f, createStairs).

            Assemble(gameData.railingPreFab, "Slab04", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab04", 0.0f).
            Assemble(gameData.railingPreFab, "Slab05", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab05", 0.0f).
            Parent(parent).
            Position(position).
            Rotate(rotation).
            Build();

        for (int l = 0; l < level - 1; l++)
        {
            go = framework.
                Blueprint(gameData.wallFramework).
                Assemble(gameData.wallPreFab, "Slab01", 0.0f).
                Assemble(gameData.wallPreFab, "Slab02", 0.0f).
                Assemble(gameData.wallPreFab, "Slab03", 0.0f).
                Assemble(gameData.wallPreFab, "Slab04", 0.0f).
                Assemble(gameData.wallPreFab, "Slab05", 0.0f).
                Position(position - new Vector3(0.0f, l * 5.0f + 2.5f, 0.0f)).
                Parent(parent).
                Rotate(rotation).
                Build();
        }
    }
}
