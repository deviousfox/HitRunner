using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float _maxHealth;

     private float currentHealth;

     private Chunk parentChunk;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        currentHealth = _maxHealth;
    }

    public void Attack(Transform target)
    {
        _agent.SetDestination(target.position);
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= _maxHealth;
        if (currentHealth<= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        parentChunk.RemoveEnemy(this);
        Destroy(_agent);
        Rigidbody[] rigidbodies  = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
}
