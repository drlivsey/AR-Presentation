using System;
using UnityEngine;

namespace ARPresentation.Interactions
{
    public class ModelZoomer : MonoBehaviour
    {
        [SerializeField] private float m_sensivity = 0.5f;
        [SerializeField] private Transform m_targetModel;

        private Vector3 m_defaultScale;

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

        private void ZoomModel(Touch firstTouch, Touch secondTouch)
        {
            var firstTouchPreviousPosition = firstTouch.position - firstTouch.deltaPosition;
            var secondTouchPreviousPosition = secondTouch.position - secondTouch.deltaPosition;

            var previousTouchDeltaMagnitude = (firstTouchPreviousPosition - secondTouchPreviousPosition).magnitude;
            var touchDeltaMagnitude = (firstTouch.position - secondTouch.position).magnitude;

            var deltaMagnitudeDiff = previousTouchDeltaMagnitude - touchDeltaMagnitude;

            var scaleDelta = deltaMagnitudeDiff * m_sensivity;

            m_targetModel.localScale -= new Vector3(scaleDelta, scaleDelta, scaleDelta);
        }
    }
}