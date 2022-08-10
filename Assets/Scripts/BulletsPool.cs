using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : GenericPool<Bullet>
{
    [SerializeField] private Vector3 _holdPosition;
    public static BulletsPool Instance { get; private set; }
    public override void Start()
    {
        base.Start();
        Instance = this;
        for (int i = 0; i < _startObjectCount; i++)
        {
            var bullet = Instantiate(_prefab, _holdPosition, Quaternion.identity);
            bullet.gameObject.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public override Bullet InstantiateObject(Vector3 spawnPos)
    {
        if (currentObjectCount >= _maxObjectCount)
        {
            Debug.LogError("POOL OVERFLOW");
            return null;
        }

        if (pool.Count == 0)
        {
            currentObjectCount++;
            var bullet = Instantiate(_prefab, spawnPos, Quaternion.identity);
            return bullet;
        }
        else
        {
            var bullet = pool.Dequeue();
            bullet.transform.position = spawnPos;
            bullet.gameObject.SetActive(true);
            return bullet;
        }
    }

    public override void DestroyObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.position = _holdPosition;
        pool.Enqueue(obj);
    }
}