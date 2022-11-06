using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using ARPresentation.Extensions;

namespace ARPresentation.Interactions
{
    public class PlacementIndicator : MonoBehaviour
    {
        [SerializeField] private bool m_enableOnStart = false;
        [SerializeField] private ARRaycastManager m_raycastManager;
        [SerializeField] private GameObject m_visualIndicator;

        private Coroutine m_indicationRoutine;

        public Vector3 IndicatorPosition
        {
            get;
            private set;
        }

        private void Awake()
        {
            if (!m_raycastManager)
            {
                throw new NullReferenceException("AR Raycast manager is not asigned!");
            }

            if (!m_visualIndicator)
            {
                throw new NullReferenceException("Visual indicator prefab is not asigned!");
            }

            if (m_visualIndicator.IsPrefab())
            {
                m_visualIndicator = Instantiate<GameObject>(m_visualIndicator);
                m_visualIndicator.SetActive(false);
            }
        }

        private void Start()
        {
            if (m_enableOnStart)
            {
                BeginIndication();
            }
        }

        public void BeginIndication()
        {
            if (m_indicationRoutine != null)
            {
                StopCoroutine(m_indicationRoutine);
            }

            m_indicationRoutine = StartCoroutine(UpdateIndicatopPosition());
            m_visualIndicator.SetActive(true);
        }

        public void StopIndication()
        {
            if (m_indicationRoutine != null)
            {
                StopCoroutine(m_indicationRoutine);
            }

            m_visualIndicator.SetActive(false);
        }

        private IEnumerator UpdateIndicatopPosition()
        {
            var waitFor = new WaitForEndOfFrame();
            while (true)
            {
                Raycast();
                yield return waitFor;
            }
        }

        private void Raycast()
        {
            var raycastHits = new List<ARRaycastHit>();
            m_raycastManager.Raycast(new Vector2(Screen.width / 2f, Screen.height / 2f), raycastHits, TrackableType.Planes);

            if (raycastHits.Count == 0)
            {
                m_visualIndicator.SetActive(false);
                return;
            }

            m_visualIndicator.transform.position = raycastHits[0].pose.position;
            m_visualIndicator.transform.rotation = raycastHits[0].pose.rotation;
            m_visualIndicator.SetActive(true);
            
            IndicatorPosition = raycastHits[0].pose.position;
        }
    }
}