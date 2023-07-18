using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchwayDoorCntrl : MonoBehaviour
{
    [SerializeField] private GameObject fxDoor;

    public Skeleton5x5Arena arena { set; get; }

    public void ShutArchway()
    {
        fxDoor.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Archway Door ...");

        if (other.CompareTag("Player"))
        {
            arena.ShutAllArchway(other.gameObject);
        }
    }
}
