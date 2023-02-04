using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    [SerializeField] private string _highestScoreKey;

    private int _highestScore;
    private int _currentScore;

    private bool _highestScoreSaved => PlayerPrefs.HasKey(_highestScoreKey);

    private void Awake()
    {
        
    }

    private void Start()
    {
        Init();
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
    }

    private void UpdateCurrentScore()
    {
        // TODO
    }

    private void UpdateHighestScore()
    {
        if (_currentScore > _highestScore)
        {
            PlayerPrefs.SetInt(_highestScoreKey, _currentScore);
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
