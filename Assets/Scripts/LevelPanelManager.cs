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
    public GameObject[] lockIcons;

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

            bool unlocked = LevelSystem.IsLevelUnlocked(currentGame, levelIndex);

            levelButtons[i].interactable = unlocked;

            if (lockIcons != null && i < lockIcons.Length)
                lockIcons[i].SetActive(!unlocked);

            int capturedIndex = levelIndex;
            levelButtons[i].onClick.RemoveAllListeners();
            levelButtons[i].onClick.AddListener(() => LoadLevel(capturedIndex));
        }
    }

    void LoadLevel(int level)
    {
        string sceneName = currentGame + "_Level" + level;
        SceneManager.LoadScene(sceneName);
    }
}
