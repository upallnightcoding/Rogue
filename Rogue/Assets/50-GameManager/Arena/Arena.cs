using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arena 
{
    protected GameData gameData;

    public Arena(GameData gameData)
    {
        this.gameData = gameData;
    }

    abstract public void Render(MazeCell mazeCell, Vector3 center);

    abstract public bool IsStartingArena();

    abstract public Vector3 GetCenterPoint();

    abstract public RuneCntrl GetRuneCntrl();
}
