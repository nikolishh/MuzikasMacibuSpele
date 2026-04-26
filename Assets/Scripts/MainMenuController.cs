using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void LoadQuizGame()
    {
        SceneManager.LoadScene("QuizGame");
    }

    public void LoadQuizGame2()
    {
        SceneManager.LoadScene("QuizGame2");
    }

    public void LoadQuizGame3()
    {
        SceneManager.LoadScene("QuizGame3");
    }

    public void LoadInstrumentGame()
    {
        SceneManager.LoadScene("InstrumentGame");
    }

    public void LoadInstrumentGame2()
    {
        SceneManager.LoadScene("InstrumentGame2");
    }

    public void LoadInstrumentGame3()
    {
        SceneManager.LoadScene("InstrumentGame3");
    }
}