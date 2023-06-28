using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : _MonoBehaviour
{
    [SerializeField] private static SoundManager instance;
    public static SoundManager Instance => instance;

    [SerializeField] protected List<AudioSource> audioSources;
    [SerializeField] protected List<AudioSource> audioEffects;
    [SerializeField] protected List<AudioSource> audioMusics;

    [SerializeField] protected float allVolume = 1;
    [SerializeField] protected float effectVolume = 1;
    [SerializeField] protected float musicVolume = 1;

    protected override void Awake()
    {
        base.Start();
        if (SoundManager.instance != null) return;
        SoundManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.SoundUpdating), 1f, 1f);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudioSource();
    }

    protected virtual void LoadAudioSource()
    {
        if (this.audioSources.Count > 0) return;
        AudioSource[] sources = FindObjectsOfType<AudioSource>(true);
        this.audioSources.AddRange(sources);

        foreach (AudioSource source in audioSources)
        {
            switch (source.name)
            {
                case "EffectSource":
                    this.audioEffects.Add(source);
                    break;
                case "MusicSource":
                    this.audioMusics.Add(source);
                    break;
                default:
                    break;
            }
        }
    }

    protected virtual void SoundUpdating()
    {
        if (this.allVolume < 0) this.allVolume = 0;
        if (this.effectVolume < 0) this.effectVolume = 0;
        if (this.musicVolume < 0) this.musicVolume = 0;

        if (this.allVolume > 1) this.allVolume = 1;
        if (this.effectVolume > 1) this.effectVolume = 1;
        if (this.musicVolume > 1) this.musicVolume = 1;

        this.UpdateEffect();
        this.UpdateMusic();
    }

    public virtual float EffecVolume()
    {
        return this.allVolume * this.effectVolume;
    }

    public virtual float MusicVolume()
    {
        return this.allVolume * this.musicVolume;
    }

    protected virtual void UpdateEffect()
    {
        float volume = this.EffecVolume();

        foreach(AudioSource source in audioEffects)
        {
            source.volume = volume;
        }
    }

    protected virtual void UpdateMusic()
    {
        float volume = this.MusicVolume();

        foreach (AudioSource source in audioMusics)
        {
            source.volume = volume;
        }
    }
}
