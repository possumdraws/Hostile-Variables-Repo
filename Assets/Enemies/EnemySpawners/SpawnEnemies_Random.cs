using UnityEngine;
using System.Collections;
using System.ComponentModel;
public class SpawnEnemies_Random : MonoBehaviour
{
    private Transform spawnerPosition;
    [Header("Enemy Prefab (Addet)")]
    public GameObject[] basicEnemies;
    public GameObject[] heavyEnemies;
    private int pickEnemy;
    private bool pickEnemyType;
    private GameObject spawnedAddetEnemy;
    private bool canSpawn;

    public float spawnDelay;

    [SerializeField]
    private int spawned = 0;

    [Header("How Many Can Spawn Before it Stops")]
    public int maxSpawned = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get location of this spawner in the world
        spawnerPosition = transform;
    }

    // Update is called every frame
    void FixedUpdate()
    {
        //if the in game enemy exists, we cannot spawn another one.
        if (spawnedAddetEnemy == null && maxSpawned > spawned && !canSpawn)
        {
            //This just means that it wont activate until the yield is complete
            StartCoroutine(Spawn());
        }
    }

    //IEnumerator is just unity stuff for delays. its a return type
    IEnumerator Spawn()
    {
        spawnDelay = Random.Range(1f, 5f);
        //can spawn enabled when called
        canSpawn = true;
        //random value for picking type of enemy
        pickEnemyType = (Random.value < 0.9f); //% basic

        //wait for however many seconds we set this to (I did 3 for now)
        yield return new WaitForSeconds(spawnDelay);

        //spawned enemy = Instantiate(prefab, spawner gameobject pos, rotation)
        if (pickEnemyType)
        {
            if (basicEnemies.Length == 0)
            {
                Debug.LogError("Basic enemy array is empty!");
                canSpawn = false;
                yield break;
            }

            //generate random value
            pickEnemy = Random.Range(0, basicEnemies.Length);

            //check that enemy prefab exists
            if (basicEnemies[pickEnemy] == null)
            {
                Debug.LogError("Enemy prefab is missing");
                canSpawn = false;
                yield break;
            }

            //Instantiate
            spawnedAddetEnemy = Instantiate(basicEnemies[pickEnemy], spawnerPosition.position, spawnerPosition.rotation);
        }
        else
        {
            if (heavyEnemies.Length == 0)
            {
                Debug.LogError("Heavy enemy array is empty!");
                canSpawn = false;
                yield break;
            }

            //generate random value
            pickEnemy = Random.Range(0, heavyEnemies.Length);

            //check that enemy prefab exists
            if (heavyEnemies[pickEnemy] == null)
            {
                Debug.LogError("Enemy prefab is missing");
                canSpawn = false;
                yield break;
            }

            //Instantiate
            spawnedAddetEnemy = Instantiate(heavyEnemies[pickEnemy], spawnerPosition.position, spawnerPosition.rotation);

        }

        //add so it stops spawning enemies eventually
        spawned++;

        //cannot spawn until called again
        canSpawn = false;
    }
}