using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMgr : MonoBehaviour
{
    [SerializeField] private GameData gameData = null;

    private Arena[,] arenaMat = null;

    private Stack<Pair> pairStack = null;

    private int width;
    private int height;

    public Arena GetArena(int col, int row) => (arenaMat[col, row]);

    public void Initialize(GameData gameData)
    {
        this.gameData = gameData;
        this.width = gameData.width;
        this.height = gameData.height;

        this.arenaMat = new Arena[width, height];

        this.pairStack = CreatePairStack();
    }

    public void Create()
    {
        Create(new StartPointArena(gameData));

        foreach(GameObject tile in gameData.runePreFab)
        {
            Create(new Room3x3TileArena(gameData, tile));
        }

        while(pairStack.Count > 0)
        {
            Arena arena;
                
            if (Random.Range(0, 2) == 0)
            {
                arena = new Room3x3Arena(gameData);
            } 
            else
            {
                arena = new Room5x5Space(gameData);
            }

            Create(arena);
        }
    }

    private void Create(Arena arena)
    { 
        Pair colRow = pairStack.Pop();

        arenaMat[colRow.Col, colRow.Row] = arena;
    }

    private Stack<Pair> CreatePairStack()
    {
        List<Pair> pairList = new List<Pair>();

        for (int col = 0; col < width; col++)
        {
            for (int row = 0; row < height; row++)
            {
                pairList.Add(new Pair(col, row));
            }
        }

        int n = (width * height) / 2;
        int t = (width * height);

        for (int i = 0; i < n; i++)
        {
            int t1 = Random.Range(0, t);
            int t2 = Random.Range(0, t);

            Pair temp = pairList[t1];
            pairList[t1] = pairList[t2];
            pairList[t2] = temp;
        }

        Stack<Pair> pairStack = new Stack<Pair>();

        foreach(Pair pair in pairList)
        {
            pairStack.Push(pair);
        }

        return (pairStack);
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
