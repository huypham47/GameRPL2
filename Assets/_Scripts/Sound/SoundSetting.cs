using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using DG.Tweening;

public class SoundSetting : _MonoBehaviour
{
    [SerializeField] protected AudioMixer audioMixer;
    [SerializeField] protected Slider allSlider;
    [SerializeField] protected Slider musicSlider;
    [SerializeField] protected Slider effectSlider;

    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.HasKey("AllVolume"))
        {
            this.LoadVolume();
        }
        else
        {
            SetAllVolume();
            SetEffectVolume();
            SetMusicVolume();
        }
    }

    public void SetAllVolume()
    {
        float volume = allSlider.value;
        audioMixer.SetFloat("Master",volume);
        PlayerPrefs.SetFloat("AllVolume", volume);
        Debug.Log("SetAllVolume");
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetEffectVolume()
    {
        float volume = effectSlider.value;
        audioMixer.SetFloat("Effect", volume);
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }

    public virtual void LoadVolume()
    {
        allSlider.value = PlayerPrefs.GetFloat("AllVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        effectSlider.value = PlayerPrefs.GetFloat("EffectVolume");
        SetAllVolume();
    }
}
