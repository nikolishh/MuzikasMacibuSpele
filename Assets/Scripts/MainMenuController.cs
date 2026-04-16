using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadInstrumentGame()
    {
        SceneManager.LoadScene("InstrumentGame");
    }

    public void LoadInstrumentGame2()
    {
        SceneManager.LoadScene("InstrumentGame2");
    }

    public void LoadRhythmGame()
    {
        SceneManager.LoadScene("RhythmGame");
    }

    public void LoadQuizGame()
    {
        SceneManager.LoadScene("QuizGame");
    }
}
