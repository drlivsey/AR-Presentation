using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARPresentation.Interactions
{
    public class ModelPlacer : MonoBehaviour
    {
        [SerializeField] private bool m_enableOnStart = false;
        [SerializeField] private Vector3 m_offset;
        [SerializeField] private GameObject m_targetModel;
        [SerializeField] private PlacementIndicator m_indicator;
        

        private Coroutine m_placementRoutine;

        private void Awake()
        {
            if (!m_indicator)
            {
                throw new NullReferenceException("Placement indicator is not asigned!");
            }

            if (!m_targetModel)
            {
                throw new NullReferenceException("Target model is not assigned!");
            }
        }

        private void Start()
        {
            if (m_enableOnStart)
            {
                BeginPositionUpdate();
            }
        }

        public void BeginPositionUpdate()
        {
            if (m_placementRoutine != null)
            {
                StopCoroutine(m_placementRoutine);
            }

            m_placementRoutine = StartCoroutine(PositionUpdate());
        }

        public void StopPositionUpdate()
        {
            if (m_placementRoutine != null)
            {
                StopCoroutine(m_placementRoutine);
            }
        }

        private IEnumerator PositionUpdate()
        {
            var waitFor = new WaitForEndOfFrame();

            while (true)
            {
                m_targetModel.transform.position = m_indicator.IndicatorPosition + m_offset;
                yield return waitFor;
            }
        }
    }
}