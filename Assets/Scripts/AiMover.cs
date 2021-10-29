using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class AiMover : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected Animator animatorController;
    private void Awake()
    {
        navMeshAgent.enabled = false;
    }
    public virtual void MoveToPostion(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    private void Update()
    {
        animatorController.SetFloat("Speed", navMeshAgent.velocity.magnitude);

    }

    public virtual void EnableMover()
    {
        navMeshAgent.enabled = true;
    }
}
