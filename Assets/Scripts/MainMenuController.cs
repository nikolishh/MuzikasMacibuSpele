using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadInstrumentGame()
    {
        SceneManager.LoadScene("InstrumentGame");  // EXACT scene name
    }
}
