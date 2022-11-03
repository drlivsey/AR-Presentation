using System;
using UnityEngine;
using UnityEngine.UI;

namespace ARPresentation
{
    public class MenuInteractionsController : MonoBehaviour
    {
        [SerializeField] private Selectable[] m_interactableElements;
        [SerializeField] private bool m_collectElementsOnAwake = false;

        private void Awake()
        {
            if (m_collectElementsOnAwake)
            {
                CollectInteractableElements();
            }
        }

        [ContextMenu("Collect interactable elements")]
        private void CollectInteractableElements()
        {
            m_interactableElements = GetComponentsInChildren<Selectable>();
        }

        public void EnableInteractions()
        {
            SetInteractionsState(true);
        }

        public void DisableInteractions()
        {
            SetInteractionsState(false);
        }

        private void SetInteractionsState(bool state)
        {
            if (m_interactableElements == null)
            {
                throw new NullReferenceException("Elements list in empty!");
            }

            foreach (var element in m_interactableElements)
            {
                element.interactable = state;
            }
        }
    }
}