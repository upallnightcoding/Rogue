using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public GameObject Parent { get; private set; }

    public int Col { get; private set; }
    public int Row { get; private set; }

    public MazeCell North { get; set; }
    public MazeCell South { get; set; }
    public MazeCell East { get; set; }
    public MazeCell West { get; set; }

    public int Level { get; set; }

    public bool IsNorth() => (North != null);
    public bool IsSouth() => (South != null);
    public bool IsEast() => (East != null);
    public bool IsWest() => (West != null);

    public bool IsNorthDown() => (IsNorth() && (North.Level < Level));
    public bool IsSouthDown() => (IsSouth() && (South.Level < Level));
    public bool IsEastDown() => (IsEast() && (East.Level < Level));
    public bool IsWestDown() => (IsWest() && (West.Level < Level));

    public bool IsNorthEqual() => (North.Level == Level);
    public bool IsEastEqual() => (East.Level == Level);

    public int GetNorthLower() => Mathf.Min(Level, North.Level);
    public int GetEastLower() => Mathf.Min(Level, East.Level);

    public bool IsNorthDiff() => Level != North.Level;
    public bool IsEastDiff() => Level != East.Level;

    private MazeCellType cellType = MazeCellType.UNVISITED;

    public void MarkVisited() => cellType = MazeCellType.VISITED;

    public void MaskAsABlock() => cellType = MazeCellType.BLOCK;

    public bool IsUnVisited() => (cellType == MazeCellType.UNVISITED);

    public MazeCell(int col, int row) 
    {
        this.Col = col;
        this.Row = row;

        Level = 0;
        Parent = new GameObject($"MazeCell {Col}-{Row}");
    }

    public List<MazeCell> GetNeighborList()
    {
        List<MazeCell> list = new List<MazeCell>();

        if (IsNorth()) list.Add(North);
        if (IsSouth()) list.Add(South);
        if (IsEast()) list.Add(East);
        if (IsWest()) list.Add(West);

        return (list);
    }

    public int GetMazeIndex() {
        int index = 0;

        if (IsNorth()) index += 8;
        if (IsSouth()) index += 4;
        if (IsEast()) index += 2;
        if (IsWest()) index += 1;

        return(index);
    }

    public MazeLink IsNeighbor(MazeCell cell) 
    {
        return(IsNeighbor(cell.Col, cell.Row));
    }

    private MazeLink IsNeighbor(int col, int row)
    {
        bool neighbors = false;
        MazeDirection direction = MazeDirection.NORTH;

        if (Col == col) {
            neighbors = Mathf.Abs(Row - row) == 1;
            if (neighbors) {
                direction = (Row - row) == 1 ? MazeDirection.SOUTH : MazeDirection.NORTH;
            }
        } else if (Row == row) {
            neighbors = Mathf.Abs(Col - col) == 1;
            if (neighbors) {
                direction = (Col - col) == 1 ? MazeDirection.WEST : MazeDirection.EAST;
            }
        }

        Debug.Log($"Col, Row: ({Col},{col}) ({Row},{row})");

        bool isLinked = false;

        switch(direction) {
            case MazeDirection.NORTH:
                isLinked = IsNorth();
                break;
            case MazeDirection.SOUTH:
                isLinked = IsSouth();
                break;
            case MazeDirection.EAST:
                isLinked = IsEast();
                break;
            case MazeDirection.WEST:
                isLinked = IsWest();
                break;
        }

        return(neighbors ? new MazeLink(isLinked, direction) : null);
    }

    private enum MazeCellType
    {
        VISITED,
        BLOCK,
        UNVISITED
    }
}

public class MazeLink
{
    public bool IsLinked { get; private set; }
    public MazeDirection Direction { get; private set; }

    public MazeLink(bool isLinked, MazeDirection direction) 
    {
        IsLinked = isLinked;
        Direction = direction;    
    }

    public MazeDirection FlipDirection() 
    {
        MazeDirection flip = MazeDirection.NORTH;

        switch(Direction) {
            case MazeDirection.NORTH:
                flip = MazeDirection.SOUTH;
                break;
            case MazeDirection.SOUTH:
                flip = MazeDirection.NORTH;
                break;
            case MazeDirection.EAST:
                flip = MazeDirection.WEST;
                break;
            case MazeDirection.WEST:
                flip = MazeDirection.EAST;
                break;
        }

        return(flip);
    }
}

public enum MazeDirection 
{
    NORTH,
    SOUTH,
    EAST, 
    WEST
}