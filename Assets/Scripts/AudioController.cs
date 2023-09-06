using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("====Referecens====")]
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soundsSlider;
    [Space(5)]
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _soundsSource;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] AudioSettings _audioSettings;


    [Space(20)]
    [Header("====Settings====")]
    [SerializeField] AudioClip[] _sounds;


    [System.Serializable]
    public class AudioSettings
    {
        public float MusicVolume;
        public float SoundsVolume;
    }

    private void Awake()
    {
        if (File.Exists(Application.dataPath + "/AudioSettings.json")) LoadSettings();
        else
        {
            _audioSettings.MusicVolume = 0.5f;
            _audioSettings.SoundsVolume = 0.5f;
            SaveSettings();

            _musicSlider.value = _audioSettings.MusicVolume;
            _soundsSlider.value = _audioSettings.SoundsVolume;

            _musicSource.volume = _audioSettings.MusicVolume;
            _soundsSource.volume = _audioSettings.SoundsVolume;
        }
    }


    public void UpdateMusicVolume()
    {
        _audioSettings.MusicVolume = _musicSlider.value;
        UpdateAudioVolume();
        SaveSettings();
    }
    public void UpdateSoundsVolume()
    {
        _audioSettings.SoundsVolume = _soundsSlider.value;
        UpdateAudioVolume();
        SaveSettings();
    }
    private void UpdateAudioVolume()
    {
        _musicSource.volume = _audioSettings.MusicVolume;
        _soundsSource.volume = _audioSettings.SoundsVolume;
    }



    private void SaveSettings()
    {
        string jsonAudioSettings = JsonUtility.ToJson(_audioSettings);
        File.WriteAllText(Application.dataPath + "/AudioSettings.json", jsonAudioSettings);
    }
    private void LoadSettings()
    {
        string jsonAudioSettings = File.ReadAllText(Application.dataPath + "/AudioSettings.json");
        _audioSettings = JsonUtility.FromJson<AudioSettings>(jsonAudioSettings);

        _musicSlider.value = _audioSettings.MusicVolume;
        _soundsSlider.value = _audioSettings.SoundsVolume;

        UpdateAudioVolume();
    }


    public void PlaySound(int index)
    {
        _soundsSource.clip = _sounds[index];
        _soundsSource.Play();
    }
}
