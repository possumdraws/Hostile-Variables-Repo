using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private Transform spawnerPosition;
    [Header("Enemy Prefab (Addet)")]
    public GameObject addetEnemy;
    private GameObject spawnedAddetEnemy;
    private bool canSpawn;
    private int spawned = 0;
    [Header("How Many Can Spawn Before it Stops")]
    public int maxSpawned = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get location of this spawner in the world
        spawnerPosition = transform;
    }

    // Update is called 60x per second
    void Update()
    {
        //if the in game enemy exists, we cannot spawn another one.
        if (spawnedAddetEnemy == null && maxSpawned > spawned && !canSpawn)
        {
            //This just means that it wont activate until the yield is complete
            StartCoroutine(Spawn());
            //add so it stops spawning enemies eventually
            spawned++;
        }
        
    }

    //IEnumerator is just unity stuff for delays. its a return type
    IEnumerator Spawn()
    {
        canSpawn = true;

        //wait for however many seconds we set this to (I did 3 for now)
        yield return new WaitForSeconds(3f);
        //spawned enemy = Instantiate(addet prefab, spawner gameobject pos, rot)
        spawnedAddetEnemy = Instantiate(addetEnemy, spawnerPosition.position, spawnerPosition.rotation);
        
        canSpawn = false;
    }
}
