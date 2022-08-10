using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class AnimationVisualiser : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _updatingSpeed = 0.1f;

    private int paramHash = Animator.StringToHash("Speed");
    private WaitForSeconds timer;

    private void Start()
    {
        timer = new WaitForSeconds(_updatingSpeed);
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        StartCoroutine(AnimationStateUpdate());
    }

    IEnumerator AnimationStateUpdate()
    {
        while (true)
        {
            if (_agent == null)
            {
                Destroy(_animator);
                Destroy(this);
            }
            
            _animator.SetFloat(paramHash, _agent.velocity.magnitude);
            yield return timer;
        }
    }
}
