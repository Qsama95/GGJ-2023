using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameAudioController", menuName = "Controllers/GameAudioController")]
public class GameAudioController : ScriptableObject
{
    [SerializeField] private AudioContainer _audioContainer;

    public Action<string> PlayAudio;

    public void PlayAudioByID(string id)
    {
        PlayAudio?.Invoke(id);
    }

    public List<AudioContainer.AudioIDClipPair> GetAudioIDClipPairs()
    {
        return _audioContainer.GetAudioIDClipPairs();
    }
}
