using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] private GameAudioController _audioController;
    [SerializeField] private GameObject _audioSourcePrefab;

    private Dictionary<string, AudioSource> _audioIDResourcePairs = new Dictionary<string, AudioSource>();

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
        var audioIDClipPairs = _audioController.GetAudioIDClipPairs();
        foreach (AudioContainer.AudioIDClipPair pair in audioIDClipPairs)
        {
            var newAudioSourceObj = Instantiate(_audioSourcePrefab, transform);
            var newAudioSource = newAudioSourceObj.GetComponent<AudioSource>();
            newAudioSource.clip = pair.AudioClip;
            _audioIDResourcePairs.Add(pair.ID, newAudioSource);
        }
    }

    private void OnDestroy()
    {
        UnregisterListeners();
    }

    private void RegisterListeners()
    {
        _audioController.PlayAudio += PlayAudioByID;
    }

    private void UnregisterListeners()
    {
        _audioController.PlayAudio -= PlayAudioByID;
    }

    private void PlayAudioByID(string id)
    {
        _audioIDResourcePairs[id].Play();
    }
}
