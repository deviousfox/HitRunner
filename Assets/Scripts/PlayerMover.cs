using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : AiMover
{
    [SerializeField] private MoveToNextWaypoint moveToNextWaypoint;
    public void StartMove()
    {
        EnableMover();
        MoveToPostion(moveToNextWaypoint.CurrentWaypointData.WaypointTransform.position);
    }

    public override void MoveToPostion(Vector3 target)
    {
        base.MoveToPostion(target);
    }

    public override void EnableMover()
    {
        base.EnableMover();
    }
}
