using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    [SerializeField] private AudioClip[] clips = new AudioClip[0];

    public void Play(AudioSource source)
    {
        int clipIndex = UnityEngine.Random.Range(0, clips.Length);
        source.clip = clips[clipIndex];
        source.Play();
    }
}
