using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Ship _ship;
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private DeathWindow _deathWindow;

    private void Awake()
    {
        Time.timeScale = 0;
        _startWindow.gameObject.SetActive(true);
        _deathWindow.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _ship.GameOver += EndGame;
        _startWindow.ButtonClicked += StartGame;
        _deathWindow.ButtonClicked += StartGame;
    }

    private void OnDisable()
    {
        _ship.GameOver += EndGame;
        _startWindow.ButtonClicked -= StartGame;
        _deathWindow.ButtonClicked -= StartGame;
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _startWindow.gameObject.SetActive(false);
        _deathWindow.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        ResetSpawners();
        _ship.Reset();
        _scoreCounter.Reset();
        _startWindow.gameObject.SetActive(false);
        _deathWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void ResetSpawners()
    {
        _enemySpawner.ClearActiveItems();
    }
}