using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioContainer", menuName = "Containers/AudioContainer")]
public class AudioContainer : ScriptableObject
{
    [System.Serializable]
    public class AudioIDClipPair
    {
        public string ID;
        public AudioClip AudioClip;
    }

    [SerializeField] private List<AudioIDClipPair> _audioIdResourcePairs = 
        new List<AudioIDClipPair>();

    public AudioClip GetAudioClipByID(string id)
    {
        foreach(AudioIDClipPair pair in _audioIdResourcePairs)
        {
            if (pair.ID == id)
            {
                return pair.AudioClip;
            }
        }

        Debug.LogError("can not find the audio source match to the given id");
        return null;
    }

    public List<AudioIDClipPair> GetAudioIDClipPairs()
    {
        return _audioIdResourcePairs;
    }
}
