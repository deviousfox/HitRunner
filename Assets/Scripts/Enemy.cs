using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float _maxHealth;
    [SerializeField] private EnemyDataHolder _enemyDataHolder;

     private float currentHealth;

     private Chunk parentChunk;

     public void SetParentChunk(Chunk chunk)
     {
         parentChunk = chunk;
     }
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

    public virtual void Die()
    {
        Destroy(_enemyDataHolder.EnemyAttack);
        Destroy(_enemyDataHolder.AnimationVisualiser);
        Destroy(_enemyDataHolder.Animator);
        Destroy(_enemyDataHolder);
        parentChunk.RemoveEnemy(this);
        _agent.enabled = false;
        Rigidbody[] rigidbodies  = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
}
