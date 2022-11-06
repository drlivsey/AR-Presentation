using System;
using UnityEngine;
using UnityEngine.Events;

using ARPresentation.Extensions;

namespace ARPresentation.Interactions
{
    [RequireComponent(typeof(PlacementIndicator))]
    public class ObjectInstantiator : MonoBehaviour
    {
        [SerializeField] private PlacementIndicator m_indicator;
        [SerializeField] private GameObject m_objectPrefab;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onObjectInstantiate;

        private GameObject m_instance;

        private void OnValidate()
        {
            if (!m_indicator)
            {
                m_indicator = GetComponent<PlacementIndicator>();
            }
        }

        private void Awake()
        {
            if (!m_indicator)
            {
                throw new NullReferenceException("Placement indicator is not asigned!");
            }
        }

        public void Instantiate()
        {
            if (m_instance)
            {   
                Destroy(m_instance);
            }

            m_instance = Instantiate<GameObject>(m_objectPrefab);
            m_instance.transform.position = m_indicator.IndicatorPosition;


        }

        public bool TryGetInstance(out GameObject instance)
        {
            instance = m_instance;
            return instance;
        }
    }
}