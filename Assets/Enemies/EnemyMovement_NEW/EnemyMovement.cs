using UnityEngine;
using System.Collections.Generic; // ADDED: needed for list of free spots

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    public int currentRow = 0;
    public int currentIndex;
    public float moveSpeed = 3f; // speed to move toward next point
    public float moveCheckDelay = 5f; // wait time before checking next spot

    [SerializeField]
    private TrackSpotOccupation track;
    private Transform targetPoint;

    private bool isMoving = false;
    private float idleTimer = 5f; // timer for idle

    //allows spawner to assign the correct track
    public void SetTrack(TrackSpotOccupation assignedTrack)
    {
        track = assignedTrack;
    }

    void Start()
    {
        // find the TrackSpotOccupation component
        //in parent? get this working bruhh ;-;

        // REMOVED: FindFirstObjectByType (causes all enemies to use same track)
        // track = GameObject.FindFirstObjectByType<TrackSpotOccupation>();

        //safety check so enemy doesn't run without a track
        if (track == null)
        {
            Debug.LogError("TrackSpotOccupation not assigned to enemy!");
            Destroy(gameObject);
            return;
        }

        //choose a random FREE spot in the starting row
        currentIndex = GetRandomFreeIndexInRow(currentRow);

        if (track == null)
        {
            Debug.LogError("TrackSpotOccupation not found");
            enabled = false;
            return;
        }

        //if no free spot exists, destroy this enemy to prevent overlap
        if (currentIndex == -1)
        {
            Debug.LogWarning("No free spawn spots in row!");
            Destroy(gameObject);
            return;
        }

        // set initial position directly to MovePoint (sprites are bottom-pivot)
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
        if (isMoving)
        {
            // move toward the target point smoothly (Y is directly taken from MovePoint)
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

            // snap to target to remove tiny float errors
            if ((transform.position - targetPoint.position).sqrMagnitude < 0.0001f)
            {
                transform.position = targetPoint.position;

                // update current row
                currentRow = Mathf.Min(currentRow + 1, track.Rows.Length - 1);

                // finished moving, start idle timer
                isMoving = false;
                idleTimer = moveCheckDelay;
            }

            return;
        }

        // count down the idle timer
        idleTimer -= Time.deltaTime;

        if (idleTimer > 0f)
        {
            return; //stay idle until timer finishes
        }

        // check for next point after idle
        int nextRow = currentRow + 1;

        if (nextRow >= track.Rows.Length)
        {
            // no more rows, reset timer to keep checking (optional)
            idleTimer = moveCheckDelay;
            return;
        }

        // pick a random free spot in the next row
        int nextIndex = GetRandomFreeIndexInRow(nextRow);

        if (nextIndex == -1)
        {
            // next row full, stay idle
            idleTimer = moveCheckDelay;
            return;
        }

        Transform nextPoint = track.GetPointTransform(nextRow, nextIndex);

        if (nextPoint == null)
        {
            // stay idle if nextPoint is null
            idleTimer = moveCheckDelay;
            return;
        }

        // free current spot and occupy next
        track.SetOccupied(currentRow, currentIndex, false);
        track.SetOccupied(nextRow, nextIndex, true);

        // set target for smooth movement
        targetPoint = nextPoint;
        currentIndex = nextIndex; // update to new index
        isMoving = true;
    }

    // gets a random free index in a given row
    int GetRandomFreeIndexInRow(int row)
    {
        List<int> freeIndexes = new List<int>();

        for (int i = 0; i < track.Rows[row].MovePoints.Length; i++)
        {
            if (track.IsSpotFree(row, i))
            {
                freeIndexes.Add(i);
            }
        }

        if (freeIndexes.Count == 0)
        {
            return -1; // no free spots
        }

        return freeIndexes[Random.Range(0, freeIndexes.Count)];
    }

    // free the spot when the enemy is destroyed
    void OnDestroy()
    {
        if (track != null)
        {
            track.SetOccupied(currentRow, currentIndex, false);
        }
    }
}