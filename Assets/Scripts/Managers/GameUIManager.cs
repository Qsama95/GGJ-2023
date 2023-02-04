using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private List<UICanvasView> _uiCanvasGroups;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void Init()
    {
        _uiCanvasGroups = new List<UICanvasView>(FindObjectsOfType<UICanvasView>());
    }

    private void SwitchUI(UIState state)
    {
        // TODO
    }
}

public enum UIState
{
    InGame,
    Pause,
    End
}

public enum UIType
{
    InGame,
    Pause,
    End
}
