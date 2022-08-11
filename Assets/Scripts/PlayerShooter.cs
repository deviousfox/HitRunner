using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    private BulletsPool bulletsPool => BulletsPool.Instance;
    private Camera cam;
    public bool CanShoot;


    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(!CanShoot) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(Input.mousePosition);
        }
    }

    private void Shoot(Vector3 mousePos)
    {
        Ray camRay = cam.ScreenPointToRay(mousePos);
        RaycastHit camRayHit = new RaycastHit();
        if (Physics.Raycast(camRay, out camRayHit, 100f))
        {
            var position = shootingPoint.position;
            var bulletDir = (camRayHit.point - position).normalized;
            var bullet = bulletsPool.InstantiateObject(position);
            bullet.Init(bulletDir);
        }
        else
        {
            var position = shootingPoint.position;
            var bulletDir = (camRay.GetPoint(100) - position).normalized;
            var bullet = bulletsPool.InstantiateObject(position);
            bullet.Init(bulletDir);
        }
    }
}
