using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextRound : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI finalScoreText;
    public int totalQuestions = 10;
    private int questionCount = 0;
    public int score = 0;

    public void AdvanceRound()
    {
        questionCount++;
        if (questionCount > totalQuestions)
        {
            ShowEndPanel();
            return;
        }

    }

    void ShowEndPanel()
    {
        endPanel.SetActive(true);
        finalScoreText.text = "Your Score: " + score;
    }

    public void TryAgain()
    {
        score = 0;
        questionCount = 0;
        endPanel.SetActive(false);
        AdvanceRound();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("QuizGame2");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}