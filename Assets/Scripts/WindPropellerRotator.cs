using System;
using UnityEngine;

using ARPresentation.Enums;

namespace ARPresentation
{
    public class WindPropellerRotator : MonoBehaviour
    {
        [SerializeField] private Transform m_target;
        [SerializeField] private CoordinatesTypes m_rotationCoords;
        [SerializeField] private bool m_rotateOnAwake = false;
        [SerializeField] private Vector3 m_deltaPerFrame;

        private bool m_isRotating = false;

        private void Awake()
        {
            if (!m_target)
            {
                throw new NullReferenceException("Target is not asigned!");
            }

            m_isRotating = m_rotateOnAwake;
        }

        private void Update()
        {
            if (!m_isRotating) return;

            if (m_rotationCoords == CoordinatesTypes.Local)
            {
                RotateLocal();
                return;
            }
            else if (m_rotationCoords == CoordinatesTypes.Global)
            {
                RotateGlobal();
                return;
            }
        }

        public void StartRotation() => m_isRotating = true;

        public void StopRotation() => m_isRotating = false;

        private void RotateLocal()
        {
            var localRotation = m_target.localEulerAngles + m_deltaPerFrame;
            m_target.localEulerAngles = localRotation;
        }

        private void RotateGlobal()
        {
            var globalRotation = m_target.eulerAngles + m_deltaPerFrame;
            m_target.eulerAngles = globalRotation;
        }
    }
}