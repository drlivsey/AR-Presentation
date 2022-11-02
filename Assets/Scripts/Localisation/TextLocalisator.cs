using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace ARPresentation.Localisation
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextLocalisator : BaseLocalisator
    {
        [SerializeField] private TMP_Text m_targetTextElement;
        [SerializeField] private TextLocalisation[] m_localisations;

        public override void ChangeLocalisation(string localisation)
        {
            if (m_targetTextElement == null && !TryGetComponent<TMP_Text>(out m_targetTextElement))
            {
                throw new NullReferenceException("Target text element in null!");
            }

            if (m_localisations == null) 
            {
                throw new NullReferenceException("There are no available localisations!");
            }

            if (!m_localisations.Any(x => x.Name.Equals(localisation)))
            {
                Debug.LogError($"There are no such localisation as {localisation}!");
                return;
            }

            var localisedText = m_localisations
                            .FirstOrDefault(x => x.Name.Equals(localisation))
                            .Value;

            m_targetTextElement.text = localisedText;
        }
    }
}