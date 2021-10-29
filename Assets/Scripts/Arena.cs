using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Arena : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] private UnityEvent OnClearCallback;

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
            OnClearCallback?.Invoke();
    }

    public void StartArena(Transform targetPosition)
    {
        foreach (var enemy in enemies)
        {
            enemy.EnableEnemy();
            enemy.GetComponent<AiMover>().MoveToPostion(targetPosition.position);
        }
    }
}
