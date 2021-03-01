using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public Sound[] sounds;
    public static AudioManager Instance;

    private int _currentBackgroundMusic = 0;
    private bool _isPlaying;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
            
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    private void Start()
    {
        Play(sounds[_currentBackgroundMusic].soundName);
    }

    private void Update()
    {
        if (!sounds[_currentBackgroundMusic].source.isPlaying)
        {
            _currentBackgroundMusic++;
            if (_currentBackgroundMusic > 2)
                _currentBackgroundMusic = 0;
            Play(sounds[_currentBackgroundMusic].soundName);
        }
    }

    public void Play(string soundName)
    {
        Sound s = null;
        foreach (Sound sound in sounds)
        {
            if (sound.soundName == soundName)
            {
                s = sound;
                break;
            }
        }

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
