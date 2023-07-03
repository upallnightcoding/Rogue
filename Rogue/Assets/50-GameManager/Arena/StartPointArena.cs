using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointArena : Arena
{
    private Vector3 centerPoint;

    public StartPointArena(GameData gameData) : base(gameData)
    {

    }

    public override Vector3 GetCenterPoint()
    {
        return (centerPoint);
    }

    public override bool IsStartingArena()
    {
        return (true);
    }

    public override RuneCntrl GetRuneCntrl()
    {
        return (null);
    }

    public override void Render(MazeCell mazeCell, Vector3 center)
    {
        Framework.CreateObject(gameData.startPointPreFab, center, 0.0f, mazeCell.Parent);

        float distance = 2.0f * gameData.tileSize;

        centerPoint = center;

        CreateSide(mazeCell.IsNorth(), center + new Vector3(0.0f, center.y, distance), mazeCell.Parent);
        CreateSide(mazeCell.IsSouth(), center + new Vector3(0.0f, center.y, -distance), mazeCell.Parent);
        CreateSide(mazeCell.IsEast(), center + new Vector3(distance, center.y, 0.0f), mazeCell.Parent);
        CreateSide(mazeCell.IsWest(), center + new Vector3(-distance, center.y, 0.0f), mazeCell.Parent);
    }

    private void CreateSide(bool hasPassage, Vector3 position, GameObject parent)
    {
        if (hasPassage)
        {
            GameObject tile = Framework.PickFromList(gameData.tilePreFab);

            Framework.CreateObject(tile, position, Framework.Rotate90Degree(), parent);
        }
    }

    
}
