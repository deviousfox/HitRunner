using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(damage);
        }

        FindObjectOfType<PoolComponent>().ReturnToPool(gameObject);
    }
}
