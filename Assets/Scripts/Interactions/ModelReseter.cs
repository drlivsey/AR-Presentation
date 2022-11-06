using System;
using UnityEngine;
using UnityEngine.Events;

namespace ARPresentation.Interactions
{
    public class ModelReseter : MonoBehaviour
    {
        [SerializeField] private ModelXRay m_modelXRay;
        [SerializeField] private ModelRotator m_modelRotator;
        [SerializeField] private ModelZoomer m_modelZoomer;
        [SerializeField] private ModelAssembler m_modelAssembler;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onModelReseted;

        public UnityEvent OnModelReseted => m_onModelReseted;

        private void Awake()
        {
            if (!m_modelXRay)
            {
                throw new NullReferenceException("Model X-Ray is not asigned!");
            }

            if (!m_modelRotator)
            {
                throw new NullReferenceException("Model rotator is not asigned!");
            }

            if (!m_modelZoomer)
            {
                throw new NullReferenceException("Model zoomer is not asigned!");
            }

            if (!m_modelZoomer)
            {
                throw new NullReferenceException("Model assembler is not asigned!");
            }
        }

        public void ResetModel()
        {
            m_modelZoomer.ResetModelScale();
            m_modelRotator.ResetModelRotation();
            m_modelXRay.DisableXRay();
            m_modelAssembler.Assemble();
        }
    }
}