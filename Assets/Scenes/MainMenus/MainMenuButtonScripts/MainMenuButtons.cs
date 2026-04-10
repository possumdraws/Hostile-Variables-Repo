using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public AudioSource menuButtonClick;
    public void QuitGame()
    {
        //qquit editor play mode
        menuButtonClick.Play();

        EditorApplication.isPlaying = false;    
        
        Application.Quit();
    }
}
