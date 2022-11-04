using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using ARPresentation.Extensions;

namespace ARPresentation.Interactions
{
    [RequireComponent(typeof(Renderer))]
    public class XRayRenderer : MonoBehaviour
    {
        [SerializeField] private int m_priority = 3000;
        [SerializeField] private Color m_xRayColor;
        [SerializeField] private Material m_xRayMaterial;
        [SerializeField] private Renderer m_renderer;

        private Material[] m_defaultMaterials;
        private Material[] m_xRayMaterials;

        private void OnValidate()
        {
            if (!m_renderer)
            {
                m_renderer = GetComponent<Renderer>();
            }
        }

        private void Awake()
        {
            if (!m_renderer)
            {
                throw new NullReferenceException("Renderer is not asigned!");
            }

            if (!m_xRayMaterial)
            {
                throw new NullReferenceException("X-Ray material is not asigned!");
            }

            m_defaultMaterials = m_renderer.materials;
            m_xRayMaterials = new Material[m_defaultMaterials.Length];
            var materialInstance = Instantiate<Material>(m_xRayMaterial);
            materialInstance.color = m_xRayColor;
            materialInstance.renderQueue = m_priority;
            m_xRayMaterials.Fill(materialInstance);
        }

        public void EnableXRay()
        {
            m_renderer.materials = m_xRayMaterials;
        }

        public void DisableXRay()
        {
            m_renderer.materials = m_defaultMaterials;
        }
    }
}