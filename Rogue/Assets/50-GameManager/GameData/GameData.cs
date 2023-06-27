using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameData", menuName="Rogue/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Maze Data")]
    public int width;
    public int height;
    public int tileSize;
    public float tileRise;

    [Header("Shared Variables")]
    public Vector3 playerStartingArena;

    [Header("Player Attributes")]
    public float moveSpeed;
    public float rotationSpeed;

    [Header("Camera Attributes")]
    public float cameraFollowSpeed;
    public float cameraLookSpeed;
    public float cameraPivotSpeed;
    public float minmaxPivotAngle;

    [Header("PreFabs")]
    public GameObject[] tilePreFab;
    public GameObject[] tileOffSetPreFab;
    public GameObject[] runePreFab;
    public GameObject[] wallsPreFab;
    public GameObject[] doorPreFab;
    public GameObject[] railingPreFab;
    public GameObject[] statuePreFab;
    public GameObject[] pillarPreFab;
    public GameObject startPointPreFab;
    public GameObject stairsSimplePreFab;
    public GameObject halfWallPreFab;
    public GameObject archwayPreFab;

    [Header("Frameworks")]
    public GameObject tileFramwork;
    public GameObject wallFramework;
}
