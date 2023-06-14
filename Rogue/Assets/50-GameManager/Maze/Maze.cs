using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze 
{
    public int Width { get; set; }
    public int Height { get; set; }

    private MazeCell[,] maze = null;

    private int RandNumber(int n) => UnityEngine.Random.Range(0, n);

    private NeighborCell[] neighbors = {
        new NeighborCell( 0,  1),
        new NeighborCell( 0, -1),
        new NeighborCell( 1,  0),
        new NeighborCell(-1,  0),
    };

    public Maze(GameData gameData)
    {
        this.Width = gameData.width;
        this.Height = gameData.height;

        Initialize();

        Generate();
    }

    public bool IsLinkedNorth(int col, int row)
    {
        MazeCell cell = GetMazeCell(col, row);

        return((cell != null) ? (cell.North != null) : false);
    }

    public bool IsLinkedEast(int col, int row)
    {
        MazeCell cell = GetMazeCell(col, row);

        return((cell != null) ? (cell.East != null) : false);
    }

    private void Generate()
    {
        Stack<MazeCell> stack = new Stack<MazeCell>();
        int nCells = Width * Height;
        int cellCount = 1;

        MazeCell cell = PickRandomCell();
        cell.MarkVisited();
        //cell.count = 1;

        while (cellCount < nCells) {
            MazeCell neighbor = PickValidNeighbor(cell);

            if (neighbor != null) {
                LinkMazeCells(cell, neighbor);
                stack.Push(cell);
                neighbor.MarkVisited();

                cell = neighbor;
                cellCount++;
                //neighbor.count = cellCount;
            } else {
                cell = stack.Pop();
            }
        }
    }

    private void LinkMazeCells(MazeCell first, MazeCell second) 
    {
        if (first.Col == second.Col) {
            if (first.Row > second.Row) {
                first.South = second;
                second.North = first;
            } else {
                second.South = first;
                first.North = second;
            }
        } else {
            if (first.Col < second.Col) {
                first.East = second;
                second.West = first;
            } else {
                second.East = first;
                first.West = second;
            }
        }
    }

    private MazeCell PickValidNeighbor(MazeCell pivot)
    {
        List<MazeCell> neighborList = new List<MazeCell>();

        foreach (NeighborCell neighbor in neighbors) {
            MazeCell cell = GetNeighborCell(pivot, neighbor);

            if ((cell != null) && (cell.IsUnVisited())) {
                neighborList.Add(cell);
            }
        }

        MazeCell choice = 
            (neighborList.Count != 0) ? neighborList[RandNumber(neighborList.Count)] : null;

        return(choice);
    }

    private MazeCell GetNeighborCell(MazeCell cell, NeighborCell neighbor) 
    {
        int col = cell.Col + neighbor.Col;
        int row = cell.Row + neighbor.Row;

        return(GetMazeCell(col, row));
    }

    private MazeCell PickRandomCell()
    {
        int col = RandNumber(Width);
        int row = RandNumber(Height);
        MazeCell cell = GetMazeCell(col, row);

        return(cell);
    }

    private void Initialize() 
    {
        maze = new MazeCell[Width, Height];

        for (int col = 0; col < Width; col++) {
            for (int row = 0; row < Height; row++) {
                maze[col, row] = new MazeCell(col, row);
            }
        }
    }

    public MazeCell GetMazeCell(int col, int row) 
    {
        MazeCell cell = null;

        if ((col >= 0) && (row >= 0) && (col < Width) && (row < Height)) {
            cell = maze[col, row];
        }

        return(cell);
    }

    public class NeighborCell {
        public int Col { get; private set; }
        public int Row { get; private set; }

        public NeighborCell(int col, int row) {
            this.Col = col;
            this.Row = row;
        }
    }
}

public enum Direction
{
    NORTH = 0,
    EAST = 1,
    SOUTH = 2,
    WEST = 3
}
