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

    abstract public void Create(MazeCell mazeCell, Vector3 center);
}
