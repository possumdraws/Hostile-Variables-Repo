using UnityEngine;

public class CheckIsPaused : MonoBehaviour
{
    //need to see this in PullUpCalculator so it doesn't interfere, therefore public static
    public static bool paused = false;
    public GameObject pauseMenuCanvas;//canvas object
    public GameObject UICanvas;//player UI

    void Start()
    {
        paused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    //Pause
    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
            UICanvas.SetActive(false);
        }
        paused = true;
        //Cursor.visible = paused;
        //Cursor.lockState = CursorLockMode.None;
    }

    //Resume
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
            UICanvas.SetActive(true);
        }
        paused = false;
        //Cursor.visible = paused;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}