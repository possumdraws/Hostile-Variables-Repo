using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;
    public CountAllEnemies countAllEnemies;
    public Canvas LevelCompleteCanvas;

    public float delayMenuPopup;
    bool levelCompleteTriggered;

    CheckIsPaused pauseCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseCheck = FindAnyObjectByType<CheckIsPaused>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        countAllEnemies = FindFirstObjectByType<CountAllEnemies>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!levelCompleteTriggered && scoreKeeper.kills >= countAllEnemies.EnemyCount)
        {
            levelCompleteTriggered = true;
            delayMenuPopup = 1.5f;
        }

        if (levelCompleteTriggered)
        {
            delayMenuPopup -= Time.deltaTime;

            if (delayMenuPopup <= 0)
            {
                LevelCompleteCanvas.gameObject.SetActive(true);
                Debug.Log("Level Complete! :D");

                // Optional: stop this from running again
                levelCompleteTriggered = false;
            }
        }
    }
}
