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
    public GameObject title;
    public GameObject[] audioButtons;
    public float endDelay = 0.5f;
    public AudioSource audioSource;
    public AudioClip correctSound;
    public AudioClip wrongSound;

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

        StartCoroutine(ShowEndPanel());

        if (title != null)
            title.SetActive(false);

        foreach (GameObject button in audioButtons)
        {
            if (button != null)
                button.SetActive(false);
        }

        enabled = false;
    }

    IEnumerator ShowEndPanel()
    {
        yield return new WaitForSeconds(endDelay);

        endPanel.SetActive(true);

        endPanel.transform.localScale = Vector3.zero;

        float duration = 0.3f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float scale = Mathf.Lerp(0f, 1f, time / duration);
            endPanel.transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        endPanel.transform.localScale = Vector3.one;
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

    public void PlayCorrect()
    {
        if (audioSource != null && correctSound != null)
            audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrong()
    {
        if (audioSource != null && wrongSound != null)
            audioSource.PlayOneShot(wrongSound);
    }
}