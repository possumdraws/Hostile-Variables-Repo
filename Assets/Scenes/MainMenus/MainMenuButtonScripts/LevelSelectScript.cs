using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public CheckIsPaused checkIsPaused;
    //we will adjust these later.
    public AudioSource menuButtonClick;

    public void LevelOne()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        checkIsPaused.ResumeGame();
    }
    public void LevelTwo()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        checkIsPaused.ResumeGame();
    }
    public void LevelThree()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        checkIsPaused.ResumeGame();
    }

    public void DevLevelSecret()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        checkIsPaused.ResumeGame();
    }
}
