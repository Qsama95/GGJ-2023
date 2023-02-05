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

    public UIType UiType { get => _uiType; set => _uiType = value; }

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
            DOFadeUI(1, () => {
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            });
        }
        else
        {
            // TODO
            DOFadeUI(0, () => {
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            });
        }
    }

    private void DOFadeUI(float fadeVar, Action onComplete = null)
    {
        _canvasGroup.DOFade(fadeVar, 0.25f);
        onComplete?.Invoke();
    }
}
