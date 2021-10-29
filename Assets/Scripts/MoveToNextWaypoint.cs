using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MoveToNextWaypoint : MonoBehaviour
{
    [SerializeField]private WaypointData currentWaypoint;

    public WaypointData CurrentWaypointData => currentWaypoint;
    public void MoveNextWaypoint()
    {
        currentWaypoint = currentWaypoint.NextWaypoint;
    }
}
