using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMgr : MonoBehaviour
{
    [SerializeField] private GameData gameData = null;

    private Arena[,] arenaMat = null;

    private Stack<Pair> colRowStack = null;

    private RuneCntrl[] runeCntrlList = null;

    private int currentRune = 0;

    //private Arena startingPointArena = null;

    private int width;
    private int height;

    public Arena GetArena(int col, int row) => (arenaMat[col, row]);

    //public Vector3 GetStartingPoint() => (startingPointArena.GetCenterPoint());

    public void Initialize(GameData gameData)
    {
        this.gameData = gameData;
        this.width = gameData.width;
        this.height = gameData.height;

        this.arenaMat = new Arena[width, height];

        this.runeCntrlList = new RuneCntrl[5];

        this.colRowStack = CreatePairStack();
    }

    /**
     * Render() - 
     */
    public void Render(int col, int row, MazeCell mazeCell, Vector3 center)
    {
        Arena arena = GetArena(col, row);

        arena.Render(mazeCell, center);

        RuneCntrl runeCntrl = arena.GetRuneCntrl();

        if (runeCntrl != null)
        {
            runeCntrlList[runeCntrl.RuneTileIndex] = runeCntrl;
        }
    }

    public void TurnOn(int runTileIndex)
    {
        runeCntrlList[runTileIndex].TurnRuneOn();
    }

    public void CreateAllArenas()
    {
        // Define the starting arena of the game.
        Create(new StartPointArena(gameData));

        // Define the five rune locations in the game.
        for (int runeTileIndex = 0; runeTileIndex < gameData.runePreFab.Length; runeTileIndex++)
        {
            Create(new Room3x3TileArena(gameData, runeTileIndex));
        }

        // Layout the remaining arenas in the game.
        while(colRowStack.Count > 0)
        {
            Arena arena = new Skeleton5x5Arena(gameData);
                
            /*if (Random.Range(0, 2) == 0)
            {
                arena = new Room3x3Arena(gameData);
            } 
            else
            {
                arena = new Room5x5Space(gameData);
            }*/

            Create(arena);
        }
    }

    /**
     * Create() - 
     */
    private void Create(Arena arena)
    { 
        Pair colRow = colRowStack.Pop();

        arenaMat[colRow.Col, colRow.Row] = arena;
    }

    private Stack<Pair> CreatePairStack()
    {
        List<Pair> colRowList = new List<Pair>();

        for (int col = 0; col < width; col++)
        {
            for (int row = 0; row < height; row++)
            {
                colRowList.Add(new Pair(col, row));
            }
        }

        int n = (width * height) / 2;
        int t = (width * height);

        for (int i = 0; i < n; i++)
        {
            int t1 = Random.Range(0, t);
            int t2 = Random.Range(0, t);

            Pair temp = colRowList[t1];
            colRowList[t1] = colRowList[t2];
            colRowList[t2] = temp;
        }

        Stack<Pair> colRowStack = new Stack<Pair>();

        foreach(Pair pair in colRowList)
        {
            colRowStack.Push(pair);
        }

        return (colRowStack);
    }

    private class Pair
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public Pair(int col, int row)
        {
            Col = col;
            Row = row;
        }
    }

}
