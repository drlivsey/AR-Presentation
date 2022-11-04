using System;
using UnityEngine;

namespace ARPresentation.Interactions
{
    public class ModelXRay : MonoBehaviour
    {
        [SerializeField] private bool m_collectRenderersOnAwake = false;
        [SerializeField] private GameObject m_targetModel;
        [SerializeField] private XRayRenderer[] m_xRayRenderers;

        private void Awake()
        {
            if (!m_collectRenderersOnAwake) return;

            CollectRenderers();
        }

        [ContextMenu("Collect renderers")]
        private void CollectRenderers()
        {
            if (!m_targetModel)
            {
                throw new NullReferenceException("Target object is not asigned!");
            }

            m_xRayRenderers = m_targetModel.GetComponentsInChildren<XRayRenderer>(true);
        }

        public void EnableXRay()
        {
            foreach (var xRayRenderer in m_xRayRenderers)
            {
                xRayRenderer.EnableXRay();
            }
        }

        public void DisableXRay()
        {
            foreach (var xRayRenderer in m_xRayRenderers)
            {
                xRayRenderer.DisableXRay();
            }
        }
    }
}