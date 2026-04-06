using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    public int currentRow = 0;
    public int currentIndex;
    public float moveSpeed = 2f; // speed to move toward next point
    public float moveCheckDelay = 3f; // wait time before checking next spot

    private TrackSpotOccupation track;
    private Transform targetPoint;

    private bool isMoving = false;
    private float idleTimer = 0f; // timer for idle

    void Start()
    {
        // find the TrackSpotOccupation component
        track = GameObject.FindFirstObjectByType<TrackSpotOccupation>();

        currentIndex = Random.Range(0,2);

        if (track == null)
        {
            Debug.LogError("TrackSpotOccupation not found");
            enabled = false;
            return;
        }

        // set initial position
        targetPoint = track.GetPointTransform(currentRow, currentIndex);
        if (targetPoint == null)
        {
            Debug.LogError($"null MovePoint at row {currentRow}, index {currentIndex}");
            enabled = false;
            return;
        }

        transform.position = targetPoint.position;

        // spawn point is occupied
        track.SetOccupied(currentRow, currentIndex, true);

        // start idle timer
        idleTimer = moveCheckDelay;
    }

    private void Update()
    {
        if (!isMoving)
        {
            // count down the idle timer
            idleTimer -= Time.deltaTime;

            if (idleTimer <= 0f)
            {
                // check for next point after idle
                int nextRow = currentRow + 1;
                if (nextRow >= track.Rows.Length)
                {
                    // no more rows, reset timer to keep checking (optional)
                    idleTimer = moveCheckDelay;
                    return;
                }

                int nextIndex = Mathf.Min(currentIndex, track.Rows[nextRow].MovePoints.Length - 1);
                Transform nextPoint = track.GetPointTransform(nextRow, nextIndex);

                if (nextPoint != null && track.IsSpotFree(nextRow, nextIndex))
                {
                    // free current spot and occupy next
                    track.SetOccupied(currentRow, currentIndex, false);
                    track.SetOccupied(nextRow, nextIndex, true);

                    // set target for smooth movement
                    targetPoint = nextPoint;
                    isMoving = true;
                }
                else
                {
                    // stay idle. we'll handle the sprite stuff here i believe?
                    idleTimer = moveCheckDelay; // reset timer if next spot is occupied
                }
            }
        }
        else
        {
            // move toward the target point smoothly
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                moveSpeed * Time.deltaTime
            );

            // snap to target to remove tiny float errors
            if ((transform.position - targetPoint.position).sqrMagnitude < 0.05f)
            {
                transform.position = targetPoint.position;

                // update current row and index
                currentRow = Mathf.Min(currentRow + 1, track.Rows.Length - 1);
                currentIndex = Mathf.Min(currentIndex, track.Rows[currentRow].MovePoints.Length - 1);

                // finished moving, start idle timer
                isMoving = false;
                idleTimer = moveCheckDelay;
            }
        }
    }
}