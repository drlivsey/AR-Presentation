using System;
using UnityEngine;
using UnityEngine.UI;

namespace ARPresentation
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Toggle m_audioToggle;
        [SerializeField] private AudioSource m_targetAudioSource;

        private void Awake()
        {
            if (!m_audioToggle)
            {
                throw new NullReferenceException("Audio toggle is not asigned!");
            }

            if (!m_targetAudioSource)
            {
                throw new NullReferenceException("Audio source is not asigned!");
            }
        }

        private void OnEnable()
        {
            m_audioToggle?.onValueChanged.AddListener(OnToggleStateChanged);
        }

        private void OnDisable()
        {
            m_audioToggle?.onValueChanged.RemoveListener(OnToggleStateChanged);
        }

        private void OnToggleStateChanged(bool value)
        {
            m_targetAudioSource.mute = !value;
        }
    }
}