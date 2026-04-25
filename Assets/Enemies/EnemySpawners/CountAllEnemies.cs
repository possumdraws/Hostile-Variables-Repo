using UnityEngine;

public class CountAllEnemies : MonoBehaviour
{
    public int EnemyCount;

    //will count how many enemies will come out of a given spawner
    //this will be used to make sure that a level ends when all enemies are defeated
    public int GetEnemyCountInSpawner(int WillSpawnHere)
    {
        EnemyCount += WillSpawnHere;
        Debug.Log("Enemy Count in Spawner (" + EnemyCount + ")");
        return EnemyCount;
    }
}
