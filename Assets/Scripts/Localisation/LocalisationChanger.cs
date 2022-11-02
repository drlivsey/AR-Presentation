using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPresentation.Localisation
{
    public class LocalisationChanger : MonoBehaviour
    {
        [SerializeField] private bool m_collectLocalisatorsOnAwake = false;
        [SerializeField] private BaseLocalisator[] m_localisatorsList;

        private void Awake()
        {
            if (m_collectLocalisatorsOnAwake)
            {
                CollectLocalisators();
            }
        }
        
        [ContextMenu("Collect localisators")]
        private void CollectLocalisators()
        {
            m_localisatorsList = FindObjectsOfType<BaseLocalisator>();
        }

        public void ChangeLocalisation(string localisation)
        {
            if (m_localisatorsList == null)
            {
                CollectLocalisators();
            }

            foreach (var localisator in m_localisatorsList)
            {
                localisator.ChangeLocalisation(localisation);
            }
        }
    }
}