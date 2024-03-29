using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private String[] music = { "NightLife", "RetroWave", "Hardbeat", "DarkTheme", "Anime", "Hardbass", "Pixel" };

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = PlayerPrefs.GetFloat("MusicVolume");
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        if (PlayerPrefs.GetString("GameMode") == "singleplayer")
        {
            FindObjectOfType<AudioManager>().Play(music[PlayerPrefs.GetInt("selectedCar")]);
        }
        else if (PlayerPrefs.GetString("GameMode") == "multiplayer")
        {
            FindObjectOfType<AudioManager>().Play(music[PlayerPrefs.GetInt("selectedGround")]);
        }
        sounds[8].source.volume = PlayerPrefs.GetFloat("EngineVolume");
        Play("EngineSound");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    public void Update()
    {
        sounds[sounds.Length-1].source.volume = PlayerPrefs.GetFloat("EngineVolume");


        for (int i = 0; i < sounds.Length-1; i++)
        {
            sounds[i].source.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
