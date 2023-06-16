using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameData", menuName="Rogue/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Maze Data")]
    public int width;
    public int height;

    [Header("Player Attributes")]
    public float moveSpeed;
    public float rotationSpeed;

    [Header("Camera Attributes")]
    public float cameraFollowSpeed;
    public float cameraLookSpeed;
    public float cameraPivotSpeed;

    [Header("PreFabs")]
    public GameObject testTilePrefab;
    public GameObject test9TilePreFab;
    public GameObject testTilePreFab;
    public GameObject[] tilePreFab;
    public GameObject[] tileOffSetPreFab;
    public GameObject[] runePreFab;
    public GameObject[] wallsPreFab;
    public GameObject[] doorPreFab;
    public GameObject archwayPreFab;
    public GameObject simpleRailingPreFab;
    public GameObject stairsSimplePreFab;
    public GameObject halfWallPreFab;

    [Header("Frameworks")]
    public GameObject tileFramwork;
    public GameObject wallFramework;
}
