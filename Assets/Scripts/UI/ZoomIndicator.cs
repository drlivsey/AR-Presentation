using System;
using UnityEngine;
using TMPro;

using ARPresentation.Interactions;
using ARPresentation.Extensions;

namespace ARPresentation.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class ZoomIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_targetTextElement;
        [SerializeField] private ModelZoomer m_zoomer;

        private void OnValidate()
        {
            if (!m_targetTextElement)
            {
                m_targetTextElement = GetComponent<TMP_Text>();
            }
        }

        private void Awake()
        {
            if (!m_targetTextElement)
            {
                throw new NullReferenceException("Target text element is not assigned!");
            }

            if (!m_zoomer)
            {
                throw new NullReferenceException("Model zoomer is not assigned!");
            }
        }

        private void OnEnable()
        {
            m_zoomer.OnScaleChanged?.AddListener(UpdateZoomLabel);
        }

        private void OnDisable()
        {
            m_zoomer.OnScaleChanged?.RemoveListener(UpdateZoomLabel);
        }

        private void UpdateZoomLabel()
        {
            var currentZoom = m_zoomer.CurrentScale.Sum() / m_zoomer.DefaultScale.Sum() * 100;
            m_targetTextElement.text = ((int)currentZoom).ToString() + " %";
        }
    }
}