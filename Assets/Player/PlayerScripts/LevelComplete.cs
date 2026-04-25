using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;
    public CountAllEnemies countAllEnemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        countAllEnemies = FindFirstObjectByType<CountAllEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreKeeper.kills >= countAllEnemies.EnemyCount)
        {
            //complete level
            Debug.Log("Level Complete! :D");
        }
    }
}
