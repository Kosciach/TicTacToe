using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Camera _camera;
    [SerializeField] Image _pauseMenu;
    [SerializeField] Image _creditsMenu;
    [Space(5)]
    [SerializeField] Slider _redSlider;
    [SerializeField] Slider _greenSlider;
    [SerializeField] Slider _blueSlider;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] Color _backgroundColor;
    [SerializeField] ColorPickerSettings _colorPickerSettings;


    [System.Serializable]
    public class ColorPickerSettings
    {
        public float Red;
        public float Green;
        public float Blue;
    }


    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/ColorPickerSettings.json")) LoadSettings();
        else
        {
            _colorPickerSettings.Red = 0.8078432f;
            _colorPickerSettings.Green = 0.4156863f;
            _colorPickerSettings.Blue = 0.4705883f;
            SaveSettings();

            _redSlider.value = _colorPickerSettings.Red;
            _greenSlider.value = _colorPickerSettings.Green;
            _blueSlider.value = _colorPickerSettings.Blue;

            UpdateColor();
        }
    }


    public void UpdateRed()
    {
        _backgroundColor.r = _redSlider.value;
        _colorPickerSettings.Red = _redSlider.value;
        UpdateColor();
        SaveSettings();
    }
    public void UpdateGreen()
    {
        _backgroundColor.g = _greenSlider.value;
        _colorPickerSettings.Green = _greenSlider.value;
        UpdateColor();
        SaveSettings();
    }
    public void UpdateBlue()
    {
        _backgroundColor.b = _blueSlider.value;
        _colorPickerSettings.Blue = _blueSlider.value;
        UpdateColor();
        SaveSettings();
    }

    private void UpdateColor()
    {
        _camera.backgroundColor = _backgroundColor;
        _pauseMenu.color = _backgroundColor;
        _creditsMenu.color = _backgroundColor;
    }


    private void SaveSettings()
    {
        string jsonColorPickerSettings = JsonUtility.ToJson(_colorPickerSettings);
        File.WriteAllText(Application.persistentDataPath + "/ColorPickerSettings.json", jsonColorPickerSettings);
    }
    private void LoadSettings()
    {
        string jsonColorPickerSettings = File.ReadAllText(Application.persistentDataPath + "/ColorPickerSettings.json");
        _colorPickerSettings = JsonUtility.FromJson<ColorPickerSettings>(jsonColorPickerSettings);

        _redSlider.value = _colorPickerSettings.Red;
        _greenSlider.value = _colorPickerSettings.Green;
        _blueSlider.value = _colorPickerSettings.Blue;

        _backgroundColor.r = _colorPickerSettings.Red;
        _backgroundColor.g = _colorPickerSettings.Green;
        _backgroundColor.b = _colorPickerSettings.Blue;

        UpdateColor();
    }
}
