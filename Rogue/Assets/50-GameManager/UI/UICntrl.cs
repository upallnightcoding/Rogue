using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICntrl : MonoBehaviour
{
    [SerializeField] private TMP_Text gemCountText;

    private int gemCount = 0;

    void Start()
    {
        gemCountText.text = "";
    }

    public void AddGemCount(int count)
    {
        gemCount += count;

        gemCountText.text = gemCount.ToString();
    }
}
