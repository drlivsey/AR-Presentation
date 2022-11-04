using System;
using UnityEngine;

namespace ARPresentation.Interactions
{
    public class ModelRotator : MonoBehaviour
    {
        [SerializeField] private float m_sensivity = 0.5f;
        [SerializeField] private Transform m_targetModel;

        private void Awake() 
        {
            if (!m_targetModel)
            {   
                throw new NullReferenceException("Target model is not assigned!");
            }
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

        private void RotateModel(Touch touch)
        {
            var delta = -touch.deltaPosition.x * m_sensivity;
            var rotationDelta = Quaternion.Euler(0f, delta, 0f);
            m_targetModel.localRotation *= rotationDelta;
        }
    }
}