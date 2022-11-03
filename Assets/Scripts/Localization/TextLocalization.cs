using System;
using UnityEngine;

namespace ARPresentation.Localization
{
    [Serializable]
    public class TextLocalization : ARPresentation.Localization.Localisation
    {
        [SerializeField, TextArea(1, 5)] private string m_value;

        public string Value => m_value;
    }
}
