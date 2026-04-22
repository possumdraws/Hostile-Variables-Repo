using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    public AudioSource pauseMenuButtonSound;
    public CheckIsPaused pauseCheck;
    public void ResumeButton()
    {
        pauseMenuButtonSound.Play();
        pauseCheck.ResumeGame();
    }
    public void SettingsButton()
    {
        pauseMenuButtonSound.Play();
        //will do this later. I need to research keeping progress, saving, etc.
    }
    public void MainMenuButton()
    {
        pauseMenuButtonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGameButton()
    {
        pauseMenuButtonSound.Play();
        //qquit editor play mode
        EditorApplication.isPlaying = false;
        //close built application
        Application.Quit();
    }
    //=====RETRY BUTTON FOR GAME OVER======//
    public void RetryButton()
    {
        pauseMenuButtonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}