using System.Collections.Generic;
using UnityEngine;

public class TrackSpotOccupation : MonoBehaviour
{
    //row array to hold their movepoints
    [System.Serializable]
    public class Row
    {
        public MovePoint[] MovePoints;
    }
    //movepoints
    [System.Serializable]
    public class MovePoint
    {
        public bool occupied;
        public GameObject movePoint;
    }

    //array to hold multiple row classes
    public Row[] Rows;

    public bool IsSpotFree(int row, int index)
    {
        if (row < 0 || row >= Rows.Length) return false;
        if (index < 0 || index >= Rows[row].MovePoints.Length) return false;
        return !Rows[row].MovePoints[index].occupied;
    }

    public void SetOccupied(int row, int index, bool value)
    {
        if (row < 0 || row >= Rows.Length) return;
        if (index < 0 || index >= Rows[row].MovePoints.Length) return;
        Rows[row].MovePoints[index].occupied = value;
    }

    public Transform GetPointTransform(int row, int index)
    {
        if (row < 0 || row >= Rows.Length) return null;
        if (index < 0 || index >= Rows[row].MovePoints.Length) return null;
        return Rows[row].MovePoints[index].movePoint.transform;
    }
}
