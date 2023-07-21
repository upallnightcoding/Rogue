using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton5x5Arena : Arena
{
    private readonly Vector3 NORTH_WALL_ROTATE = new Vector3(0.0f, 0.0f, 0.0f);
    private readonly Vector3 SOUTH_WALL_ROTATE = new Vector3(0.0f, 180.0f, 0.0f);
    private readonly Vector3 EAST_WALL_ROTATE = new Vector3(0.0f, 90.0f, 0.0f);
    private readonly Vector3 WEST_WALL_ROTATE = new Vector3(0.0f, -90.0f, 0.0f);

    private Vector3 centerPoint;
    private MazeCell mazeCell = null;

    private List<ArchwayDoorCntrl> archwayList = null;

    private int level = -1;

    private GameObject spawnPoint = null;

    public Skeleton5x5Arena(GameData gameData) : base(gameData)
    {
        archwayList = new List<ArchwayDoorCntrl>();
    }

    public override Vector3 GetCenterPoint() => centerPoint;

    public override RuneCntrl GetRuneCntrl() => null;

    public override bool IsStartingArena() => false;

    public override void Render(MazeCell mazeCell, Vector3 center)
    {
        centerPoint = center;
        this.mazeCell = mazeCell;

        CreateFloor(mazeCell, center);
        CreateSides(mazeCell, center);
    }

    public void ShutAllArchway(GameObject player)
    {
        foreach(ArchwayDoorCntrl cntrl in archwayList)
        {
            cntrl.ShutArchway();
        }

        Vector3 position = centerPoint + new Vector3(0.0f, 1.1f + mazeCell.Level * gameData.tileRise, 0.0f);
        GameObject seleton = Framework.CreateObject(gameData.skeletonSlavePreFab, position, Framework.Rotate90Degree());
        seleton.GetComponent<SeletonSlaveCntrl>().SetPlayer(player);
    }

    private void CreateFloor(MazeCell mazeCell, Vector3 center)
    {
        Vector3 position = new Vector3();

        spawnPoint = new GameObject("SpawnPoint");
        spawnPoint.transform.position = center;
        spawnPoint.transform.parent = mazeCell.Parent.transform;

        for (int x = -2; x <= 2; x++)
        {
            for (int z = -2; z <= 2; z++)
            {
                position.x = center.x + x * gameData.tileSize;
                position.y = center.y;
                position.z = center.z + z * gameData.tileSize;

                Framework.CreateObject(gameData.tilePreFab, position, Framework.Rotate90Degree(), mazeCell.Parent);
            }
        }
    }

    private void CreateSides(MazeCell mazeCell, Vector3 center)
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
        GameObject archwayPreFab = (hasPassage) ? gameData.archwayDoorPreFab : Framework.PickFromList(gameData.railingPreFab);
        GameObject archway = null;

        Framework framework = new Framework();

        GameObject go = framework.
            Blueprint(gameData.wallFramework).
            Assemble(gameData.railingPreFab, "Slab01", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab01", 0.0f).
            Assemble(gameData.railingPreFab, "Slab02", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab02", 0.0f).
            Assemble(archwayPreFab, "Slab03", 180.0f, true, out archway).
            Assemble(gameData.halfWallPreFab, "Slab03", 0.0f).
            Assemble(gameData.railingPreFab, "Slab04", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab04", 0.0f).
            Assemble(gameData.railingPreFab, "Slab05", Framework.Rotate180Degree()).
            Assemble(gameData.halfWallPreFab, "Slab05", 0.0f).
            Parent(parent).
            Position(position).
            Rotate(rotation).
            Build();

        ArchwayDoorCntrl archwayDoorCntrl = archway.GetComponent<ArchwayDoorCntrl>();

        if (archwayDoorCntrl != null)
        {
            archwayDoorCntrl.arena = this;
            archwayList.Add(archwayDoorCntrl);
        }

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
