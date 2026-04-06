using System.Collections;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{/*
  * 
  //TEMPORARILY TURNED OFF TO WORK ON NEW MOVEMENT SYSTEM
    public Transform playerTarget;
    public float enemyMoveSpeed = 10f;

    [HideInInspector]
    public bool moving = true;


    //public float stopDistance = 0.5f; // distance when to stop (will implement later
    //maybe it will be attack distance? longer for ranged enemies, shorter for melee? idk)
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("playerHitbox").transform;
        //start
        StartCoroutine(StopStartMovement());
    }
    // Update is called once per frame
    void Update()
    {
        if (playerTarget == null)
        {  return; }

        if (moving)
        {
            MoveTowards();
        }
    }

    void MoveTowards()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, playerTarget.position,
            enemyMoveSpeed * Time.deltaTime
            );
    }

    IEnumerator StopStartMovement()
    {
        while (true)
        {
            //wait
            yield return new WaitForSeconds(3);
            //flip
            moving = !moving;
        }
    }*/
}