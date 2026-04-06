using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Image questionImage;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public Button yesButton;
    public Button noButton;

    [Header("Settings")]
    public float timePerQuestion = 5f;

    private int score = 0;
    private float timer;
    private bool isAnswering = false;

    [Header("Quiz Content")]
    public Sprite[] questionSprites;
    public bool[] answers;
    private int currentQuestion = 0;

    void Start()
    {
        yesButton.onClick.AddListener(() => Answer(true));
        noButton.onClick.AddListener(() => Answer(false));
        scoreText.text = "Score: 0";
        NextQuestion();
    }

    void Update()
    {
        if (isAnswering)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                timer = 0;
                isAnswering = false;
                currentQuestion++;
                NextQuestion();
            }
        }
    }

    void NextQuestion()
    {
        if (currentQuestion < questionSprites.Length)
        {
            questionImage.sprite = questionSprites[currentQuestion];
            timer = timePerQuestion;
            isAnswering = true;
        }
        else
        {
            questionImage.gameObject.SetActive(false);
            timerText.text = "";
            questionImage.gameObject.SetActive(false);
            yesButton.interactable = false;
            noButton.interactable = false;
            scoreText.text = "Final Score: " + score;
        }
    }

    void Answer(bool playerAnswer)
    {
        if (!isAnswering) return;

        isAnswering = false;

        if (playerAnswer == answers[currentQuestion])
        {
            score++;
            scoreText.text = "Score: " + score;
        }

        currentQuestion++;
        NextQuestion();
    }
}