using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointData : MonoBehaviour
{
    [SerializeField] private Transform waypointTransform;
    [SerializeField] private WaypointData nextWaypoint;

    private void Awake()
    {
        waypointTransform ??= transform;
    }

    public Transform WaypointTransform => waypointTransform;
    public WaypointData NextWaypoint => nextWaypoint;
    
}
