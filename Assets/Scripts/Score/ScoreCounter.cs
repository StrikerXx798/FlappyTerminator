using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private const int InitialScore = 0;
    private const int ScoreIncrement = 1;

    private int _score;

    public Action<int> ScoreChanged;

    private void Awake()
    {
        Reset();
    }

    public void AddScore()
    {
        _score += ScoreIncrement;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = InitialScore;
        ScoreChanged?.Invoke(_score);
    }
}