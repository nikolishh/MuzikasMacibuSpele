using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPanelManager : MonoBehaviour
{
    public GameObject panel;
    public Text titleText;

    public Button[] levelButtons;

    private string currentGame;

    public void OpenPanel(string gameName)
    {
        panel.SetActive(true);
        currentGame = gameName;
        titleText.text = gameName;

        SetupLevels();
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    void SetupLevels()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;

            levelButtons[i].GetComponentInChildren<Text>().text = "Level " + levelIndex;

            levelButtons[i].onClick.RemoveAllListeners();
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    void LoadLevel(int level)
    {
        string sceneName = currentGame + "_Level" + level;
        SceneManager.LoadScene(sceneName);
    }
}
