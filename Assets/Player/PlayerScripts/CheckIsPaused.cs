using UnityEngine;

public class CheckIsPaused : MonoBehaviour
{
    //need to see this in PullUpCalculator so it doesn't interfere, therefore public static
    public static bool paused = false;

    [Header("Canvases")]
    public GameObject pauseMenuCanvas;//canvas object
    public GameObject UICanvas;//player UI
    public GameObject GameOverCanvas; //game over canvas
    public GameObject ControlsCanvas;
    public GameObject NextLevelCanvas;

    [Header("Health Stuff")]
    public bool isAlive;
    public PlayerHealth playerHealth;

    void OnEnable()
    {
        isAlive = true;

        paused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if(UICanvas != null)
        {
            UICanvas.SetActive(true);
        }
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }

        if (GameOverCanvas != null)
        {
            GameOverCanvas.SetActive(false);
        }
        if(ControlsCanvas != null)
        {
            ControlsCanvas.SetActive(false);
        }
        if(NextLevelCanvas != null)
        {
            NextLevelCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log($"Game is paused? T/F -> {paused}");
        
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
    public void PauseGame()
    {
        Time.timeScale = 0f;
        //AudioListener.pause = true;

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
        Debug.Log("Resume clicked");

        Time.timeScale = 1f;
        //AudioListener.pause = false;

        if (pauseMenuCanvas != null)
        {
            Debug.Log("Disabling pauseMenuCanvas: " + pauseMenuCanvas.name);
            pauseMenuCanvas.SetActive(false);
        }

        if (UICanvas != null)
        {
            Debug.Log("Enabling UICanvas: " + UICanvas.name);
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