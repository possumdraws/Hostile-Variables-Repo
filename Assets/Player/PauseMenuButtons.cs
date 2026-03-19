using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    public CheckIsPaused pauseCheck;
    public void ResumeButton()
    {
        pauseCheck.ResumeGame();
    }

    public void SettingsButton()
    {
        //will do this later. I need to research keeping progress, saving, etc.
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGameButton()
    {
        //qquit editor play mode
        EditorApplication.isPlaying = false;
        //close built application
        Application.Quit();
    }
}