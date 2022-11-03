using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace ARPresentation.Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextLocalizator : BaseLocalizator
    {
        [SerializeField] private TMP_Text m_targetTextElement;
        [SerializeField] private TextLocalization[] m_localizations;

        public override void ChangeLocalization(string localization)
        {
            if (m_targetTextElement == null && !TryGetComponent<TMP_Text>(out m_targetTextElement))
            {
                throw new NullReferenceException("Target text element in null!");
            }

            if (m_localizations == null) 
            {
                throw new NullReferenceException("There are no available localizations!");
            }

            if (!m_localizations.Any(x => x.Name.Equals(localization)))
            {
                throw new InvalidOperationException($"There are no such localization as {localization}!");
            }

            var localizedText = m_localizations
                            .FirstOrDefault(x => x.Name.Equals(localization))
                            .Value;

            m_targetTextElement.text = localizedText;
        }
    }
}