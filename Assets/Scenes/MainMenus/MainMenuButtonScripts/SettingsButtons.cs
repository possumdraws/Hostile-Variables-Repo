using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButtons : MonoBehaviour
{
    public AudioSource menuButtonClick;
    public void GoBack()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
