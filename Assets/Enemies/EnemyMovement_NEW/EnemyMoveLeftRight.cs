using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeftRight : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float moveCheckDelay = 2f;

    [Header("Points (set in world)")]
    public Transform pointA;
    public Transform pointB;

    private Transform targetPoint;

    public bool isMoving = false;
    private float idleTimer;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Points not assigned!");
            enabled = false;
            return;
        }

        // Start at A
        transform.position = pointA.position;

        // Pick initial target
        targetPoint = pointB;
        idleTimer = moveCheckDelay;
    }

    void Update()
    {
        if (animator != null)
            animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                moveSpeed * Time.deltaTime
            );

            if ((transform.position - targetPoint.position).sqrMagnitude < 0.001f)
            {
                transform.position = targetPoint.position;

                isMoving = false;
                idleTimer = moveCheckDelay;

                // Swap target
                targetPoint = (targetPoint == pointA) ? pointB : pointA;
            }

            return;
        }

        idleTimer -= Time.deltaTime;

        if (idleTimer <= 0f)
        {
            isMoving = true;
        }
    }
}
