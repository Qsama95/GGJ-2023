using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UICanvasView : MonoBehaviour
{
    [SerializeField] private UIType _uiType;
    private CanvasGroup _canvasGroup;

    public Action<bool> FadeUI;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        FadeUI += OnFadeUI;
    }

    private void OnDestroy()
    {
        FadeUI -= OnFadeUI;
    }

    private void OnFadeUI(bool isFadeIn)
    {
        if (isFadeIn)
        {
            // TODO
        }
        else
        {
            // TODO
        }
    }
}
