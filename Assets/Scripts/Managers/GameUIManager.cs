using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private List<UICanvasView> _uiCanvasGroups;

    [SerializeField] private GameUIController _gameUIController;
    [SerializeField] private UIType _activeUIType;

    private void Awake()
    {
        RegisterListeners();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _uiCanvasGroups = new List<UICanvasView>(FindObjectsOfType<UICanvasView>());
        _gameUIController.SwitchUIType?.Invoke(UIType.InGame);
    }

    private void OnDestroy()
    {
        UnregisterListeners();
    }

    private void RegisterListeners()
    {
        _gameUIController.SwitchUIType += SwitchUI;
    }

    private void UnregisterListeners()
    {
        _gameUIController.SwitchUIType -= SwitchUI;
    }

    private void SwitchUI(UIType activeUIType)
    {
        _activeUIType = activeUIType;
        // TODO
        foreach (UICanvasView uICanvasView in _uiCanvasGroups)
        {
            if (uICanvasView.UiType == activeUIType)
            {
                uICanvasView.FadeUI?.Invoke(true);
            }
            else
            {
                uICanvasView.FadeUI?.Invoke(false);
            }
        }
    }
}

public enum UIType
{
    InGame,
    Pause,
    End
}
