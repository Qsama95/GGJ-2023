using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerScoreController _scoreController;
    [SerializeField] private string _highestScoreKey;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _currentScoreTMP;
    [SerializeField] private TextMeshProUGUI _highestScoreTMP;
    [SerializeField] private TextMeshProUGUI _timeLeftTMP;

    private int _highestScore;
    private int _currentScore;
    private int _timeLeft;

    private bool _highestScoreSaved => PlayerPrefs.HasKey(_highestScoreKey);

    private void Awake()
    {
        RegisterListeners();
    }

    private void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        UnregisterListeners();
    }

    private void RegisterListeners()
    {
        _scoreController.UpdateScore += UpdateCurrentScore;
    }

    private void UnregisterListeners()
    {
        _scoreController.UpdateScore -= UpdateCurrentScore;
    }

    private void Init()
    {
        _currentScore = 0;

        if (_highestScoreSaved)
        {
            _highestScore = PlayerPrefs.GetInt(_highestScoreKey);
        }
        else
        {
            PlayerPrefs.SetInt(_highestScoreKey, 0);
        }
        //ClearHighestScore();
    }

    private void UpdateCurrentScore(int scoreToAdd)
    {
        // TODO
        _currentScore += scoreToAdd;
        _currentScoreTMP.text = _currentScore.ToString();
        UpdateHighestScore();
    }

    private void UpdateHighestScore()
    {
        if (_currentScore > _highestScore)
        {
            _highestScore = _currentScore;
            _highestScoreTMP.text = _currentScore.ToString();
            PlayerPrefs.SetInt(_highestScoreKey, _highestScore);
        }
    }

    private void ClearHighestScore()
    {
        if (_highestScoreSaved)
        {
            PlayerPrefs.DeleteKey(_highestScoreKey);
        }
    }
}
