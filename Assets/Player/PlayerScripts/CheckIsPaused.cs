using UnityEngine;

public class CheckIsPaused : MonoBehaviour
{
    //need to see this in PullUpCalculator so it doesn't interfere, therefore public static
    public static bool paused = false;

    [Header("Canvases")]
    public GameObject pauseMenuCanvas;//canvas object
    public GameObject UICanvas;//player UI
    public GameObject GameOverCanvas; //game over canvas

    [Header("Health Stuff")]
    public bool isAlive;
    public PlayerHealth playerHealth;
    void Start()
    {
        isAlive = true;

        paused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }
        if (GameOverCanvas != null)
        {
            GameOverCanvas.SetActive(false);
        }
    }
    // Update is called once per frame
    public void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && isAlive)
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

    public void Die()
    {
        PauseGame();
        pauseMenuCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
    }
}