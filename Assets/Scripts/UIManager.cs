using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject levelPanel1;
    public GameObject levelPanel2;

    private GameObject currentPanel;
    private string currentGame;

    public void OpenLevelPanel1()
    {
        CloseAllPanels();
        currentPanel = levelPanel1;
        currentPanel.SetActive(true);
        currentGame = "InstrumentGame"; 
    }

    public void OpenLevelPanel2()
    {
        CloseAllPanels();
        currentPanel = levelPanel2;
        currentPanel.SetActive(true);
        currentGame = "AnotherGame";
    }

    public void ClosePanel()
    {
        if (currentPanel != null)
            currentPanel.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        string sceneName = currentGame + "_Level" + levelIndex;
        SceneManager.LoadScene(sceneName);
    }

    private void CloseAllPanels()
    {
        if (levelPanel1 != null) levelPanel1.SetActive(false);
        if (levelPanel2 != null) levelPanel2.SetActive(false);
    }
}