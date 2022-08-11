using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackColdown = 1f;

    private WaitForSeconds timer;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            timer = new WaitForSeconds(_attackColdown);
            StartCoroutine(AttackCycle(playerHealth));
        }
    }

    private IEnumerator AttackCycle(PlayerHealth playerHealth)
    {
        while (true)
        {
            playerHealth.ApplyDamage(_damage);
            yield return timer;
        }
    }
}
