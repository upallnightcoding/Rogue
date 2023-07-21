using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject fxBeacon;

    public Vector3 Position { get; set; }

    public int RuneTileIndex { get; set; }

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();

        meshRenderer.material = gameData.runeOff;
    }

    public void TurnRuneOn()
    {
        meshRenderer.material = gameData.runeOn;

        fxBeacon.SetActive(true);
    }

    public void TurnRuneOff()
    {
        fxBeacon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Rune Control OnTriggerEnter other ...");
    }
}
