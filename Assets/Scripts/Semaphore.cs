using UnityEngine;
using UnityEngine.Events;

namespace ARPresentation
{
    public class Semaphore : MonoBehaviour
    {
        [SerializeField] private bool m_isActive;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onSemaphoreEnable;
        [SerializeField] private UnityEvent m_onSemaphoreDisable;

        public void SwitchActivity()
        {
            m_isActive = !m_isActive;

            if (m_isActive) m_onSemaphoreEnable?.Invoke();
            else m_onSemaphoreDisable?.Invoke();
        }
    }
}