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
    private GameObject spawnedAddetEnemy;
    private bool canSpawn;
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
        pickEnemy = Random.Range(0, basicEnemies.Length);

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
        canSpawn = true;

        //wait for however many seconds we set this to (I did 3 for now)
        yield return new WaitForSeconds(3f);

        //check that enemy prefab exists
        if (basicEnemies[pickEnemy] == null)
        {
            Debug.LogError("Enemy prefab is missing");
            yield break;
        }
        //spawned enemy = Instantiate(addet prefab, spawner gameobject pos, rot)
        spawnedAddetEnemy = Instantiate(basicEnemies[pickEnemy], spawnerPosition.position, spawnerPosition.rotation);

        //add so it stops spawning enemies eventually
        spawned++;

        canSpawn = false;
    }
}
