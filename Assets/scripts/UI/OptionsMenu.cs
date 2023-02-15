using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    public float MusicVolumeValue;
    public float EngineVolumeValue;

    public Slider MusicVolumeSlider;
    public Slider EngineVolumeSlider;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width==Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        //���� ����� ����� ��� ��� �� ���������� ���������� ������ �������� � ������� ��� �������������

        MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        EngineVolumeSlider.value = PlayerPrefs.GetFloat("EngineVolume");
    }

    void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolumeValue);
        PlayerPrefs.SetFloat("EngineVolume", EngineVolumeValue);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetMusicVolume(float volume)
    {
        MusicVolumeValue = volume;
    }
    public void SetEngineVolume(float volume)
    {
        EngineVolumeValue = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void FullScreen(bool IsFoolscreen)
    {
        Screen.fullScreen = IsFoolscreen;
    }
}