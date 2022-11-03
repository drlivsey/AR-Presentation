using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using ARPresentation.Localization;

namespace ARPresentation
{
    public class ApplicationSettings : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown m_localizationDropdown;
        [SerializeField] private Toggle m_musicToggle;
        [SerializeField] private Toggle m_soundsToggle;

        private void Awake()
        {
            if (!m_localizationDropdown)
            {
                throw new NullReferenceException("Localization dropdown is not asigned!");
            }

            if (!m_musicToggle)
            {
                throw new NullReferenceException("Music toggle is not asigned!");
            }

            if (!m_soundsToggle)
            {
                throw new NullReferenceException("Sounds toggle is not asigned!");
            }
        }

        private void Start()
        {
            ApplySettings();
        }

        private void OnEnable()
        {
            m_localizationDropdown?.onValueChanged.AddListener(SaveLocalizationSettings);
            m_musicToggle?.onValueChanged.AddListener(SaveMusicSettings);
            m_soundsToggle?.onValueChanged.AddListener(SaveSoundsSettings);
        }

        private void OnDisable()
        {
            m_localizationDropdown?.onValueChanged.RemoveListener(SaveLocalizationSettings);
            m_musicToggle?.onValueChanged.RemoveListener(SaveMusicSettings);
            m_soundsToggle?.onValueChanged.RemoveListener(SaveSoundsSettings);
        }

        private void ApplySettings()
        {
            var localization = PlayerPrefs.GetInt("localization", 0);
            var music = PlayerPrefs.GetInt("music", 1) == 1;
            var sounds = PlayerPrefs.GetInt("sounds", 1) == 1;

            m_localizationDropdown.value = localization;
            m_musicToggle.isOn = music;
            m_soundsToggle.isOn = sounds;
        }

        private void SaveLocalizationSettings(int value)
        {
            PlayerPrefs.SetInt("localization", value);
            PlayerPrefs.Save();
        }

        private void SaveMusicSettings(bool value)
        {
            PlayerPrefs.SetInt("music", value ? 1 : 0);
            PlayerPrefs.Save();
        }

        private void SaveSoundsSettings(bool value)
        {
            PlayerPrefs.SetInt("sounds", value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}