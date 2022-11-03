using UnityEngine;
using UnityEngine.Events;

namespace ARPresentation.Localization
{
    public class LocalizationChanger : MonoBehaviour
    {
        [SerializeField] private bool m_collectLocalizatorsOnAwake = false;
        [SerializeField] private BaseLocalizator[] m_localizatorsList;

        [Header("Events")]
        [SerializeField] private UnityEvent<string> m_onLocalizationChanged;

        public UnityEvent<string> OnLocalizationChanged => m_onLocalizationChanged;

        private void Awake()
        {
            if (m_collectLocalizatorsOnAwake)
            {
                CollectLocalizators();
            }
        }
        
        [ContextMenu("Collect localizators")]
        private void CollectLocalizators()
        {
            m_localizatorsList = FindObjectsOfType<BaseLocalizator>();
        }

        public void ChangeLocalization(string localization)
        {
            if (m_localizatorsList == null)
            {
                CollectLocalizators();
            }

            foreach (var localizator in m_localizatorsList)
            {
                localizator.ChangeLocalization(localization);
            }

            m_onLocalizationChanged?.Invoke(localization);
        }
    }
}