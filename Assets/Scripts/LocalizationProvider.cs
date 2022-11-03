using System;
using UnityEngine;
using TMPro;

using ARPresentation.Localization;

namespace ARPresentation
{
    [RequireComponent(typeof(LocalizationChanger))]
    public class LocalizationProvider : MonoBehaviour
    {
        [SerializeField] private LocalizationChanger m_targetChanger;
        [SerializeField] private TMP_Dropdown m_localizationsList;

        private void OnValidate()
        {
            m_targetChanger = this.GetComponent<LocalizationChanger>();
        }

        private void Awake()
        {
            if (!m_localizationsList)
            {
                throw new NullReferenceException("Localization list is not asigned!");
            }
        }

        private void OnEnable()
        {
            m_localizationsList?.onValueChanged.AddListener(OnLocalisationChanged);
        }

        private void OnDisable()
        {
            m_localizationsList?.onValueChanged.RemoveListener(OnLocalisationChanged);
        }
        
        private void OnLocalisationChanged(int index)
        {
            if (!m_localizationsList)
            {
                throw new NullReferenceException("Localization list is not asigned!");
            }

            if (!m_targetChanger)
            {
                throw new NullReferenceException("Localization changer is not asigned!");
            }

            var localization = m_localizationsList.options[index].text;

            m_targetChanger.ChangeLocalization(localization);
        }
    }
}