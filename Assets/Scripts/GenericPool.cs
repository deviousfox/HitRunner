using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool<T> : MonoBehaviour where T : MonoBehaviour
{
  [SerializeField] private protected T _prefab;
  [SerializeField] private protected int _maxObjectCount;
  [SerializeField] private protected int _startObjectCount;
  private protected int currentObjectCount;
  private protected Queue<T> pool;
  

  public virtual void Start()
  {
    pool = new Queue<T>();
    
  }

  public virtual T InstantiateObject(Vector3 spawnPos)
  {
    //pool.Dequeue()
    return null;
  }

  public virtual void DestroyObject(T obj)
  {
    //pool.Enqueue(obj);
  }
}
