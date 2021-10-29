using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PoolComponent pool;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool canShoot;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void SetShootState(bool state)
    {
        canShoot = state;
    }
    private void Update()
    {
        if (!canShoot) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray shootRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit shootHit = new RaycastHit();

            if (Physics.Raycast(shootRay, out shootHit))
            {
                Rigidbody rb = pool.InstantiateFromPool(shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce((shootHit.point- shootPoint.position ).normalized * bulletSpeed, ForceMode.Impulse);
            }
            else
            {
                Rigidbody rb = pool.InstantiateFromPool(shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce((shootHit.point - shootPoint.position).normalized * bulletSpeed, ForceMode.Impulse);
            }
            

        }
    }
}
