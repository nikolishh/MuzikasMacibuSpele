using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InstrumentGameManager : MonoBehaviour
{
    public KidDrag[] kids;
    public GameObject endPanel;

    void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        foreach (KidDrag kid in kids)
        {
            if (!kid.isPlaced)
            {
                return;
            }
        }

        LevelProgress.UnlockLevel("InstrumentGame", 1);

        endPanel.SetActive(true);
        enabled = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene("InstrumentGame");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}