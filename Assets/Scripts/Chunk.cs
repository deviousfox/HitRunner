using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
  public Chunk NextChunk => _nextChunk;
  public Transform PlayerPoint => _playerPoint;
  
  [SerializeField] private bool _isFinalChunk;
  [SerializeField] private Transform _playerPoint;
  [SerializeField] private Chunk _nextChunk;
  [SerializeField] private List<Enemy> _enemies;

  public void StartChunk()
  {
    foreach (var enemy in _enemies)
    {
       enemy.Attack(_playerPoint);
    }
  }

  public void RemoveEnemy(Enemy removableEnemy)
  {
    try
    {
      _enemies.Remove(removableEnemy);
      if (_enemies.Count ==0)
      {
        
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }
}
