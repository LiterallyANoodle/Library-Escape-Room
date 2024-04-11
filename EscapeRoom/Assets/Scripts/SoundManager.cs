using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SoundType
{
    LEVER,
    SOLVED_PUZZLE_ONE,
    DOOR,
    BOOK_PLACE
    PRESSED,
}

public struct Range
{
    private readonly float min;
    private readonly float max;

    public Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }

    public float GetRandomValue()
    {
        return Random.Range(min, max);
    }
}

public class SoundCollection
{
    private AudioClip[] clips;
    private int lastClipIndex;          // This will help us not be able to play the same clip more than once

    public SoundCollection(params string[] audioNames)
    {
        clips = new AudioClip[audioNames.Length];
        for (int i = 0; i < clips.Length; i++)
        {
            clips[i] = Resources.Load(audioNames[i]) as AudioClip;
            if (clips[i] == null)
            {
                Debug.LogWarning($"Couldn't find clip {audioNames[i]}");
            }
        }
        lastClipIndex = -1;
    }

    // This will grab a random clip from the array of clips we created above
    // if theres nothing in the array then error check,
    // else if there is only one clip then just play that one clip
    // else randomly select a clip from the array
    public AudioClip GetRandClip() {
        if (clips.Length == 0)
        {
            Debug.LogWarning($"No clips found");
            return null;
        }
        else if (clips.Length == 1)
        {
            return clips[0];
        }
        else
        {
            int index = Random.Range(0, clips.Length);
            return clips[index];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private Dictionary<SoundType, SoundCollection> sounds;
    private AudioSource audioSrc;
    private Range rangeVol;
    private Range rangePitch;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        sounds = new()
        {
            {SoundType.LEVER, new("Lever") },
            {SoundType.SOLVED_PUZZLE_ONE, new("Solved") },
            {SoundType.DOOR, new("Door")},
            {SoundType.BOOK_PLACE, new("BookPlace") },
            {SoundType.PRESSED, new("buttonpress")}
        };
        rangeVol = new(0.75f, 1.0f);
        rangePitch = new(0.75f, 1.25f);
    }

    public void Play(SoundType type, AudioSource audioSrc = null)
    {
        if (sounds.ContainsKey(type))
        {
            if (audioSrc == null)
            {
                this.audioSrc.volume = rangeVol.GetRandomValue();
                this.audioSrc.pitch = rangePitch.GetRandomValue();
                this.audioSrc.clip = sounds[type].GetRandClip();
                this.audioSrc.Play();
            }
            else
            {
                audioSrc.volume = rangeVol.GetRandomValue();
                audioSrc.pitch = rangePitch.GetRandomValue();
                audioSrc.clip = sounds[type].GetRandClip();
                audioSrc.Play();
            }
        }
    }
    public void Play(string type, AudioSource audioSrc) 
    {
        SoundType soundType = Enum.Parse<SoundType>(type, true);
        Play(soundType, audioSrc);
    }

    public void Play(string type)
    {
        Play(type, audioSrc);
    }

    
}

