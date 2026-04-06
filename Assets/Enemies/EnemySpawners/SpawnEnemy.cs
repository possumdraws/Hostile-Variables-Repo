using System.Collections;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Transform spawnerPosition;
    [Header("Enemy Prefab (Addet)")]
    public GameObject addetEnemy;
    private GameObject spawnedAddetEnemy;
    private bool canSpawn;
    [SerializeField]
    private int spawned = 0;

    public float spawnDelay;

    [Header("How Many Can Spawn Before it Stops")]
    public int maxSpawned = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get location of this spawner in the world
        spawnerPosition = transform;
}

    // Update is called every frame
    void Update()
    {
        //if the in game enemy exists, we cannot spawn another one.
        if (spawnedAddetEnemy == null && maxSpawned > spawned && !canSpawn)
        {
            spawnDelay = Random.Range(1f, 5f);
            //This just means that it wont activate until the yield is complete
            StartCoroutine(Spawn());
        }
        
    }

    //IEnumerator is just unity stuff for delays. its a return type
    IEnumerator Spawn()
    {
        canSpawn = true;

        //wait for however many seconds we set this to (I did 3 for now)
        yield return new WaitForSeconds(spawnDelay);

        //check that enemy prefab exists
        if(addetEnemy == null)
        {
            Debug.LogError("Enemy prefab is missing");
            yield break;
        }
        //spawned enemy = Instantiate(addet prefab, spawner gameobject pos, rot)
        spawnedAddetEnemy = Instantiate(addetEnemy, spawnerPosition.position, spawnerPosition.rotation);

        //add so it stops spawning enemies eventually
        spawned++;

        canSpawn = false;
    }
}
