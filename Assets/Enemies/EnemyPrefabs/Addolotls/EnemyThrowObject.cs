using UnityEngine;
using UnityEngine.UIElements;

public class EnemyThrowObject : MonoBehaviour
{
    public GameObject potionPrefab;
    public Transform player;
    public float projectileSpeed = 5f;
    public float destroyDistance = 0.2f;
    void Start()
    {
        // Automatically find player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("player tag not found");
        }
    }

    public void SpawnProjectile()
    {
        Vector3 spawnPos = transform.position + Vector3.up * 1f;
        GameObject potion = Instantiate(potionPrefab, spawnPos, Quaternion.identity);

        ProjectileMover mover = potion.AddComponent<ProjectileMover>();
        mover.Initialize(player, projectileSpeed, destroyDistance);
        Debug.Log("Throwable thrown");
    }
}

public class ProjectileMover : MonoBehaviour
{
    private Transform playerTarget;
    private float speed;
    private float destroyDistance;

    public void Initialize(Transform targetTransform, float moveSpeed, float dist)
    {
        playerTarget = targetTransform;
        speed = moveSpeed;
        destroyDistance = dist;
    }

    void Update()
    {
        if (playerTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            playerTarget.position,
            speed * Time.deltaTime
        );

        //spin
        transform.Rotate(0f, 0f, 360f * Time.deltaTime);

        //transform.LookAt(playerTarget);

        if (Vector3.Distance(transform.position, playerTarget.position) < destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}