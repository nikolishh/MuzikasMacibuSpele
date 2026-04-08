using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizEndPanel : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text finalScoreText; 

    void Start()
    {
        panel.SetActive(false);
    }

    public void ShowEndPanel(int score)
    {
        panel.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
    }

    // Button functions
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
