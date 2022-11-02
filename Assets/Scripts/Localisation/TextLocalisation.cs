using System;
using UnityEngine;

namespace ARPresentation.Localisation
{
    [Serializable]
    public class TextLocalisation : Localisation
    {
        [SerializeField, TextArea(1, 5)] private string m_value;

        public string Value => m_value;
    }
}
