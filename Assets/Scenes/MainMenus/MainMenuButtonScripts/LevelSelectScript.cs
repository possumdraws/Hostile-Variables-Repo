using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    //we will adjust these later.
    public AudioSource menuButtonClick;

    public void LevelOne()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LevelTwo()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void LevelThree()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void DevLevelSecret()
    {
        menuButtonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}
