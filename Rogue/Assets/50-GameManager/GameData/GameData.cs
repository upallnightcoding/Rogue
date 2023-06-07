using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameData", menuName="Rogue/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Maze Data")]
    public int width;
    public int height;

    [Header("PreFabs")]
    public GameObject testTilePrefab;
    public GameObject test9TilePreFab;
    public GameObject testTilePreFab;
    public GameObject[] tilePreFab;
    public GameObject[] runePreFab;
    public GameObject[] wallsPreFab;
    public GameObject[] doorPreFab;
    public GameObject archwayPreFab;

    [Header("Frameworks")]
    public GameObject tileFramwork;
}
