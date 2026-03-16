using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform playerTarget;
    public float enemyMoveSpeed = 10f;
    //public float stopDistance = 0.5f; // distance when to stop (will implement later
    //maybe it will be attack distance? longer for ranged enemies, shorter for melee? idk)
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("playerHitbox").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerTarget == null)
        {  return; }

        transform.position = Vector3.MoveTowards(
            transform.position, playerTarget.position,
            enemyMoveSpeed * Time.deltaTime
            );
    }
}
