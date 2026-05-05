using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public CheckIsPaused checkIsPaused;
    //we will adjust these later.
    public AudioSource menuButtonClick;

    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    public void LevelOne()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void LevelTwo()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void LevelThree()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void DevLevelSecret()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
