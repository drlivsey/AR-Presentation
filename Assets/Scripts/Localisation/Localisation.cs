using System;
using UnityEngine;

namespace ARPresentation.Localisation
{

    [Serializable]
    public class Localisation
    {
        [SerializeField] private string m_name;

        public string Name => m_name;
    }
}