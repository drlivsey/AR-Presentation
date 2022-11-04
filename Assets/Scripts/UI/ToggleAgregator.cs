using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ARPresentation.UI
{
    [RequireComponent(typeof(Toggle))]
    public class ToggleAgregator : MonoBehaviour
    {
        [SerializeField] private Toggle m_targetToggle;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onToggleChecked;
        [SerializeField] private UnityEvent m_onToggleUnchecked;

        private void OnValidate()
        {
            if (!m_targetToggle)
            {
                m_targetToggle = GetComponent<Toggle>();
            }
        }

        private void Awake()
        {
            if (!m_targetToggle)
            {
                throw new NullReferenceException("Target toggle is not assigned!");
            }
        }

        private void OnEnable()
        {
            m_targetToggle?.onValueChanged.AddListener(OnToggleStateChange);
        }

        private void OnDisable()
        {
            m_targetToggle?.onValueChanged.RemoveListener(OnToggleStateChange);
        }

        private void OnToggleStateChange(bool state)
        {
            if (state) m_onToggleChecked?.Invoke();
            else m_onToggleUnchecked?.Invoke();
        }
    }
}