using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5x5Space : Space
{
    private readonly Vector3 NORTH_WALL_ROTATE = new Vector3(0.0f, 0.0f, 0.0f);
    private readonly Vector3 SOUTH_WALL_ROTATE = new Vector3(0.0f, 180.0f, 0.0f);
    private readonly Vector3 EAST_WALL_ROTATE = new Vector3(0.0f, 90.0f, 0.0f);
    private readonly Vector3 WEST_WALL_ROTATE = new Vector3(0.0f, -90.0f, 0.0f);

    public Room5x5Space(GameData gameData) : base(gameData)
    {

    }

    public override void CreateFloor(MazeCell mazeCell, Vector3 center)
    {
        Vector3 position = new Vector3();

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -2; z <= 2; z++)
            {
                position.x = center.x + x * 5.0f;
                position.y = center.y;
                position.z = center.z + z * 5.0f; ;

                int selection = Random.Range(0, gameData.tilePreFab.Length);

                Object.Instantiate(gameData.tilePreFab[selection], position, Quaternion.identity);

                if ((x == 0) && (z == 0))
                {

                } else {

                }
            }
        }
    }

    public override void CreateWalls(MazeCell mazeCell, Vector3 center)
    {
        float distance = 2 * 5 + 5.0f / 2.0f;

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
            Assemble(gameData.wallsPreFab, "Slab01", 180.0f).
            Assemble(gameData.wallsPreFab, "Slab02", 180.0f).
            Assemble(passage, "Slab03", 180.0f).
            Assemble(gameData.wallsPreFab, "Slab04", 180.0f).
            Assemble(gameData.wallsPreFab, "Slab05", 180.0f).
            Position(position).
            Rotate(rotation).
            Build();
    }
}
