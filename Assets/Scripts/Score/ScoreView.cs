using System;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private const string ScoreFormat = "SCORE: {0}";

    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI _scoreView;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += UpdateText;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= UpdateText;
    }

    private void UpdateText(int score)
    {
        _scoreView.text = string.Format(ScoreFormat, score);
    }
}