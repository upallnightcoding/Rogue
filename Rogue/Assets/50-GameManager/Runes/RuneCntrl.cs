using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject fxBeacon;

    public int RuneTileIndex { get; set; }
    public Vector3 Position { get; set; }

    private MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();

        meshRenderer.material = gameData.runeOff;
    }

    public void TurnRunOn()
    {
        meshRenderer.material = gameData.runeOn;

        fxBeacon.SetActive(true);

        GameManager.Instance.SelectRune(RuneTileIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Rune Control OnTriggerEnter other ...");
    }
}
