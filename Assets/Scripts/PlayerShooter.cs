using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Bullet bulletObject;
    [SerializeField] private Transform shootingPoint;
    private BulletsPool bulletsPool => BulletsPool.Instance;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        
    }
}
