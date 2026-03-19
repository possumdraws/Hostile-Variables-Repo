using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    //we will adjust these later.
    public AudioSource menuButtonClick;
    public void LevelOne()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene("TestLevel");
    }
    public void LevelTwo()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene("TestLevel");
    }
    public void LevelThree()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene("TestLevel");
    }
    public void GoBack()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
