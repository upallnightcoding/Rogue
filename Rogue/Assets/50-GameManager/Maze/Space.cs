using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Space 
{
    protected GameData gameData;

    public Space(GameData gameData)
    {
        this.gameData = gameData;
    }

    abstract public void CreateFloor(MazeCell mazeCell, Vector3 center);

    abstract public void CreateSides(MazeCell mazeCell, Vector3 center);
}
