using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _playerAgent;
    [SerializeField] private Chunk _currentChunk;
    [SerializeField] private Chunk _startChunk;
    [SerializeField] private float _updatingSpeed = 0.1f;

    [SerializeField] private bool isLevelPlaying;
    
    private WaitForSeconds timer;
    private Coroutine LevelUpdater;
    private void Start()
    {
        _currentChunk = _startChunk.NextChunk;
        var position = _startChunk.PlayerPoint.position;
        _playerAgent.SetDestination(position);
        _playerAgent.transform.position = position;
        timer = new WaitForSeconds(_updatingSpeed);
    }

    public void StartLevel()
    {
       LevelUpdater = StartCoroutine(StateUpdate());
       _playerAgent.SetDestination(_currentChunk.PlayerPoint.position);
    }

    public void PauseLevel()
    {
        isLevelPlaying = false;
        _currentChunk.StartChunk();
    }

    public void ContinueLevel()
    {
        _currentChunk = _currentChunk.NextChunk;
        _playerAgent.SetDestination(_currentChunk.PlayerPoint.position);
       LevelUpdater = StartCoroutine(StateUpdate());
    }

    public void FinishLevel()
    {
        
    }
    IEnumerator StateUpdate()
    {
        while (true)
        {
            if (!isLevelPlaying) yield return null;
            
            if (_playerAgent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                PauseLevel();
            }
            else
            {
                
            }
            yield return timer;
        }
    }
}
