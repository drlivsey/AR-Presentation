using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ARPresentation.Tweeners
{
    public class TweensSequentor : Tweener
    {
        [SerializeField] private float m_additionalDelay = 0f;
        [SerializeField] private Tweener[] m_tweensSequence;
        
        [Header("Events")]
        [SerializeField] private UnityEvent m_onSequenceBegin;
        [SerializeField] private UnityEvent m_onSequenceEnd;

        public override float Duration
        {
            get 
            {
                if (m_tweensSequence == null || m_tweensSequence.Length == 0)
                    return 0f;
                
                return m_tweensSequence.Sum(x => x.Duration + x.Delay);
            }
        }
        public override float Delay => m_additionalDelay;

        public override UnityEvent OnTweenBegin => m_onSequenceBegin;
        public override UnityEvent OnTweenEnd => m_onSequenceEnd;

        public override void TweenForward()
        {
            if (m_tweensSequence == null)
            {
                throw new NullReferenceException("Tweens sequence in empty!");
            }

            // PrepareSequenceToForward();
            // m_tweensSequence.First().TweenForward();

            StartCoroutine(PlaySequenceForward());
        }

        public override void TweenBackwards()
        {
            if (m_tweensSequence == null)
            {
                throw new NullReferenceException("Tweens sequence in empty!");
            }

            // PrepareSequenceToBackwards();
            // m_tweensSequence.Last().TweenBackwards();

            StartCoroutine(PlaySequenceBackwards());
        }

        private IEnumerator PlaySequenceForward()
        {
            yield return new WaitForSeconds(m_additionalDelay);

            m_onSequenceBegin?.Invoke();

            foreach (var tweener in m_tweensSequence)
            {
                tweener.TweenForward();
                yield return new WaitForSeconds(tweener.Delay + tweener.Duration);
            }

            m_onSequenceEnd?.Invoke();
        }

        private IEnumerator PlaySequenceBackwards()
        {
            yield return new WaitForSeconds(m_additionalDelay);

            m_onSequenceBegin?.Invoke();

            foreach (var tweener in m_tweensSequence.Reverse())
            {
                tweener.TweenBackwards();
                yield return new WaitForSeconds(tweener.Delay + tweener.Duration);
            }

            m_onSequenceEnd?.Invoke();
        }

        // private void InvokeOnBegin() => m_onSequenceBegin?.Invoke();
        // private void InvokeOnEnd() => m_onSequenceEnd?.Invoke();

        // private void PrepareSequenceToForward()
        // {
        //     m_tweensSequence.First().OnTweenBegin?.AddListener(InvokeOnBegin);
        //     m_tweensSequence.Last().OnTweenEnd?.AddListener(InvokeOnEnd);
        //     m_tweensSequence.Last().OnTweenEnd?.AddListener(ResetSequenceAfterForward);

        //     for (var i = 0; i < m_tweensSequence.Length - 1; i++)
        //     {
        //         m_tweensSequence[i].OnTweenEnd?.AddListener(m_tweensSequence[i + 1].TweenForward);
        //     }
        // }

        // private void ResetSequenceAfterForward()
        // {
        //     m_tweensSequence.First().OnTweenBegin?.RemoveListener(InvokeOnBegin);
        //     m_tweensSequence.Last().OnTweenEnd?.RemoveListener(InvokeOnEnd);
        //     m_tweensSequence.Last().OnTweenEnd?.RemoveListener(ResetSequenceAfterForward);

        //     for (var i = 0; i < m_tweensSequence.Length - 1; i++)
        //     {
        //         m_tweensSequence[i].OnTweenEnd?.RemoveListener(m_tweensSequence[i + 1].TweenForward);
        //     }
        // }

        // private void PrepareSequenceToBackwards()
        // {
        //     m_tweensSequence.Last().OnTweenBegin?.AddListener(InvokeOnBegin);
        //     m_tweensSequence.First().OnTweenEnd?.AddListener(InvokeOnEnd);
        //     m_tweensSequence.First().OnTweenEnd?.AddListener(ResetSequenceAfterBackwards);

        //     for (var i = m_tweensSequence.Length - 1; i >= 1; i--)
        //     {
        //         m_tweensSequence[i].OnTweenEnd?.AddListener(m_tweensSequence[i - 1].TweenBackwards);
        //     }
        // }

        // private void ResetSequenceAfterBackwards()
        // {
        //     m_tweensSequence.Last().OnTweenBegin?.RemoveListener(InvokeOnBegin);
        //     m_tweensSequence.First().OnTweenEnd?.RemoveListener(InvokeOnEnd);
        //     m_tweensSequence.First().OnTweenEnd?.RemoveListener(ResetSequenceAfterBackwards);

        //     for (var i = m_tweensSequence.Length - 1; i >= 1; i--)
        //     {
        //         m_tweensSequence[i].OnTweenEnd?.RemoveListener(m_tweensSequence[i - 1].TweenBackwards);
        //     }
        // }
    }
}