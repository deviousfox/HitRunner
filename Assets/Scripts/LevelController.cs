using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PlayerDataHolder _playerData;
    
    [SerializeField] private Chunk _currentChunk;
    [SerializeField] private Chunk _startChunk;
    [SerializeField] private float _updatingSpeed = 0.1f;

    [SerializeField] private bool isLevelPlaying;
    [SerializeField] private UiController _uiController;
    private NavMeshAgent playerAgent => _playerData.PlayerAgent;
    private WaitForSeconds timer;
    private Coroutine LevelUpdater;
    private void Start()
    {
        _currentChunk = _startChunk.NextChunk;
        var position = _startChunk.PlayerPoint.position;
        playerAgent.SetDestination(position);
        playerAgent.transform.position = position;
        timer = new WaitForSeconds(_updatingSpeed);
    }

    public void StartLevel()
    {
       LevelUpdater = StartCoroutine(StateUpdate());
       _playerData.PlayerShooter.CanShoot = false;
       playerAgent.SetDestination(_currentChunk.PlayerPoint.position);
    }

    public void PauseLevel()
    {
        if(_currentChunk.IsFinalChunk)
            _uiController.EndGame();
        
        isLevelPlaying = false;
        _playerData.PlayerShooter.CanShoot = true;
        _currentChunk.StartChunk();
    }

    public void ContinueLevel()
    {
        _currentChunk = _currentChunk.NextChunk;
        playerAgent.SetDestination(_currentChunk.PlayerPoint.position);
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
            
            if (Vector3.Distance(playerAgent.transform.position, _currentChunk.PlayerPoint.position) < playerAgent.stoppingDistance)
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
