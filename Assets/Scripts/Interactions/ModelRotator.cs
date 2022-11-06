using System;
using UnityEngine;
using UnityEngine.Events;

namespace ARPresentation.Interactions
{
    public class ModelRotator : MonoBehaviour
    {
        [SerializeField] private float m_sensivity = 0.5f;
        [SerializeField] private Transform m_targetModel;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onRotationChanged;

        private Quaternion m_defaultRotation;

        public Quaternion DefaultRotation => m_defaultRotation;
        public UnityEvent OnRotationChanged => m_onRotationChanged;

        private void Awake() 
        {
            if (!m_targetModel)
            {   
                throw new NullReferenceException("Target model is not assigned!");
            }

            m_defaultRotation = m_targetModel.localRotation;
        }

        private void Update()
        {
            if (Input.touchCount == 1)
            {
                var touch = Input.GetTouch(0);
                
                if (touch.phase != TouchPhase.Moved) return;

                RotateModel(touch);
            }
        }

        public void ResetModelRotation()
        {
            m_targetModel.localRotation = m_defaultRotation;
        }

        private void RotateModel(Touch touch)
        {
            var delta = -touch.deltaPosition.x * m_sensivity;
            var rotationDelta = Quaternion.Euler(0f, delta, 0f);
            var calculatedRotation = m_targetModel.localRotation * rotationDelta;

            if (calculatedRotation == m_targetModel.localRotation) return;

            m_targetModel.localRotation = calculatedRotation;
            m_onRotationChanged?.Invoke();
        }
    }
}