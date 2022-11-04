using UnityEngine;

namespace ARPresentation.Animations
{
    public class AnimatorTriggerSetter : MonoBehaviour
    {
        [SerializeField] private string m_triggerName;
        [SerializeField] private Animator m_animator;

        public void SetTrigger()
        {
            m_animator.SetTrigger(m_triggerName);
        }

        public void ResetTrigger()
        {
            m_animator.ResetTrigger(m_triggerName);
        }
    }
}