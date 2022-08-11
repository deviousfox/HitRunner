using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    
    [SerializeField] private Canvas _startScreen;
    [SerializeField] private Canvas _endScreen;
    [SerializeField] private Canvas _loseScreen;
    [SerializeField] private Button _restartEnd;
    [SerializeField] private Button _restartDie;
    [SerializeField] private Button _start;

    private void Start()
    {
        _restartDie.onClick.AddListener(RestartGame);
        _restartEnd.onClick.AddListener(RestartGame);
        _start.onClick.AddListener(StartGame);
    }

    public void LoseGame()
    {
        _loseScreen.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        _endScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void StartGame()
    {
        _levelController.StartLevel();
    }
}
