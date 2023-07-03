using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UICntrl : MonoBehaviour
{
    [SerializeField] private TMP_Text gemCountText;
    [SerializeField] private RuneUI[] runeUI;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject quitPanel;

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

    public void SelectRune(int runeTileIndex)
    {
        runeUI[runeTileIndex].SelectRune();
    }

    public void SelectStartPanel()
    {
        startPanel.SetActive(true);
        settingPanel.SetActive(false);
        gamePanel.SetActive(false);
        quitPanel.SetActive(false);
    }

    public void SelectGamePanel()
    {
        startPanel.SetActive(false);
        settingPanel.SetActive(false);
        gamePanel.SetActive(true);
        quitPanel.SetActive(false);
    }

    public void QuitGamePanel()
    {
        startPanel.SetActive(false);
        settingPanel.SetActive(false);
        gamePanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    [Serializable]
    public class RuneUI
    {
        [SerializeField] public Image image;
        [SerializeField] public Image focus;

        public void SelectRune()
        {
            image.transform.gameObject.SetActive(true);
            focus.transform.gameObject.SetActive(true);
        }
    }
}
