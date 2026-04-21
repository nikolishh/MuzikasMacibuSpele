using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button quizLevel2Button;
    public Button instrumentLevel2Button;

    void Start()
    {
        if (quizLevel2Button != null)
            quizLevel2Button.interactable = LevelSystem.IsLevelUnlocked("QuizGame", 2);

        if (instrumentLevel2Button != null)
            instrumentLevel2Button.interactable = LevelSystem.IsLevelUnlocked("InstrumentGame", 2);

        Debug.Log("Quiz L1: " + PlayerPrefs.GetInt("QuizGame_Level1", 0));
        Debug.Log("Quiz L2 unlocked: " + LevelSystem.IsLevelUnlocked("QuizGame", 2));
    }

    public void LoadQuizGame()
    {
        if (LevelSystem.IsLevelUnlocked("QuizGame", 1))
            SceneManager.LoadScene("QuizGame");
    }

    public void LoadQuizGame2()
    {
        if (LevelSystem.IsLevelUnlocked("QuizGame", 2))
            SceneManager.LoadScene("QuizGame2");
    }

    public void LoadInstrumentGame()
    {
        if (LevelSystem.IsLevelUnlocked("InstrumentGame", 1))
            SceneManager.LoadScene("InstrumentGame");
    }

    public void LoadInstrumentGame2()
    {
        if (LevelSystem.IsLevelUnlocked("InstrumentGame", 2))
            SceneManager.LoadScene("InstrumentGame2");
    }
}