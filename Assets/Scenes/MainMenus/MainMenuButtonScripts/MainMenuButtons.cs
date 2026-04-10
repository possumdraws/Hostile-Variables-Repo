using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public AudioSource menuButtonClick;
    public void QuitGame()
    {
        menuButtonClick.Play();
        Application.Quit();
    }
}
