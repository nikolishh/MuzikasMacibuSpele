using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{

    [Header("UI Elements")]
    public Image questionImage;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public Button yesButton;
    public Button noButton;

    [Header("End Panel")]
    public GameObject endPanel;
    public TMP_Text finalScoreText;

    [Header("Settings")]
    public float timePerQuestion = 5f;

    private int score = 0;
    private float timer;
    private bool isAnswering = false;

    [Header("Quiz Content")]
    public Sprite[] questionSprites;
    public bool[] answers;
    private int currentQuestion = 0;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    [Header("Effects")]
    public GameObject confettiPrefab;

    void Start()
    {
        questionImage.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        yesButton.onClick.AddListener(() => Answer(true));
        noButton.onClick.AddListener(() => Answer(false));

        scoreText.text = "PUNKTI: 0";
        endPanel.SetActive(false);

        NextQuestion();
    }

    void Update()
    {
        if (isAnswering)
        {
            timer -= Time.deltaTime;
            timerText.text = "LAIKS: " + Mathf.Ceil(timer).ToString();

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
            questionImage.sprite = questionSprites[currentQuestion];
            questionImage.GetComponent<ImagePop>().Pop();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isAnswering = false;

        questionImage.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        timerText.text = "";

        endPanel.SetActive(true);

        finalScoreText.text = "PUNKTI: " + score;
    }

    void Answer(bool playerAnswer)
    {
        if (!isAnswering) return;

        isAnswering = false;

        if (playerAnswer == answers[currentQuestion])
        {
            score++;
            scoreText.text = "PUNKTI: " + score;

            audioSource.PlayOneShot(correctSound);
            PlayConfetti(playerAnswer);
        }
        else
        {
            audioSource.PlayOneShot(wrongSound);
        }

        currentQuestion++;
        Invoke("NextQuestion", 0.5f);
    }

    public void Retry()
    {
        SceneManager.LoadScene("QuizGame");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void PlayConfetti(bool playerAnswer)
    {
        Vector3 spawnPos = playerAnswer ? yesButton.transform.position : noButton.transform.position;
        Instantiate(confettiPrefab, yesButton.transform.position, Quaternion.identity, yesButton.transform.parent);
    }
}