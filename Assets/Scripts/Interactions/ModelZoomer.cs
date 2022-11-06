using System;
using UnityEngine;
using UnityEngine.Events;

using ARPresentation.Extensions;

namespace ARPresentation.Interactions
{
    public class ModelZoomer : MonoBehaviour
    {
        [SerializeField] private float m_sensivity = 0.5f;
        [SerializeField, Min(0.1f)] private float m_minScaleMultiplier = 0.5f;
        [SerializeField, Min(0.1f)] private float m_maxScaleMultiplier = 2f;
        [SerializeField] private Transform m_targetModel;
        
        [Header("Events")]
        [SerializeField] private UnityEvent m_onScaleChanged;

        private Vector3 m_defaultScale;

        public Vector3 CurrentScale => m_targetModel.localScale;
        public Vector3 DefaultScale => m_defaultScale;
        public UnityEvent OnScaleChanged => m_onScaleChanged;

        private void Awake() 
        {
            if (!m_targetModel)
            {   
                throw new NullReferenceException("Target model is not assigned!");
            }

            m_defaultScale = m_targetModel.localScale;
        }

        private void Update()
        {
            if (Input.touchCount == 2)
            {
                var firstTouch = Input.GetTouch(0);
                var secondTouch = Input.GetTouch(1);
                
                if (firstTouch.phase != TouchPhase.Moved || secondTouch.phase != TouchPhase.Moved) return;

                ZoomModel(firstTouch, secondTouch);
            }
        }

        public void ResetModelScale()
        {
            m_targetModel.localScale = m_defaultScale;
            m_onScaleChanged?.Invoke();
        }

        private void ZoomModel(Touch firstTouch, Touch secondTouch)
        {
            var scaleDelta = GetScaleDelta(firstTouch, secondTouch);
            var truncatedScale = GetTruncatedScale(m_defaultScale, m_targetModel.localScale - scaleDelta);
            
            if (truncatedScale == m_targetModel.localScale) return;

            m_targetModel.localScale = truncatedScale;
            m_onScaleChanged?.Invoke();
        }

        private Vector3 GetScaleDelta(Touch firstTouch, Touch secondTouch)
        {
            var firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
            var secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

            var previousTouchDeltaMagnitude = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
            var touchDeltaMagnitude = (firstTouch.position - secondTouch.position).magnitude;

            var deltaMagnitudeDiff = previousTouchDeltaMagnitude - touchDeltaMagnitude;

            var scaleDelta = deltaMagnitudeDiff * m_sensivity;

            return new Vector3(scaleDelta, scaleDelta, scaleDelta);
        }

        private Vector3 GetTruncatedScale(Vector3 defaultScale, Vector3 calculatedScale)
        {
            var currentScaleMultiplier = calculatedScale.Sum() / defaultScale.Sum();
            var truncatedScaleMultiplier = GetTruncatedScaleMultiplier(currentScaleMultiplier);
            
            return defaultScale * truncatedScaleMultiplier;
        }

        private float GetTruncatedScaleMultiplier(float multiplier)
        {
            if (multiplier > m_maxScaleMultiplier) return m_maxScaleMultiplier;
            if (multiplier < m_minScaleMultiplier) return m_minScaleMultiplier;
            return multiplier;
        }
    }
}