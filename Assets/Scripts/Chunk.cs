using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
  public Chunk NextChunk => _nextChunk;
  public Transform PlayerPoint => _playerPoint;
  public bool IsFinalChunk => _isFinalChunk;
  
  [SerializeField] private bool _isFinalChunk;
  [SerializeField] private Transform _playerPoint;
  [SerializeField] private Chunk _nextChunk;
  [SerializeField] private List<Enemy> _enemies;

  private void Start()
  {
    foreach (var enemy in _enemies)
    {
      enemy.SetParentChunk(this);
    }
  }

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
        FindObjectOfType<LevelController>().ContinueLevel();
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      throw;
    }
  }
}
