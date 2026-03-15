using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public AudioSource menuButtonClick;
    public void PlayGoToLevels()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene("LevelSelect");
    }
    public void GoToSettings()
    {
        menuButtonClick.Play();

    }
    public void AboutUs()
    {
        menuButtonClick.Play();

    }
    public void QuitGame()
    {
        menuButtonClick.Play();
        Application.Quit();
    }
}
