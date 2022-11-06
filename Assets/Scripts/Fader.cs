using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

namespace ARPresentation
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private bool m_unfadeOnStart;
        [SerializeField] private Image m_fadeImage;
        [SerializeField, Min(0.1f)] private float m_fadeDuration = 1f;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onFadeBegin;
        [SerializeField] private UnityEvent m_onFadeEnd;
        [SerializeField] private UnityEvent m_onFadeInBegin;
        [SerializeField] private UnityEvent m_onFadeInEnd;
        [SerializeField] private UnityEvent m_onFadeOutBegin;
        [SerializeField] private UnityEvent m_onFadeOutEnd;

        public UnityEvent OnFadeBegin => m_onFadeBegin;
        public UnityEvent OnFadeEnd => m_onFadeEnd;
        public UnityEvent OnFadeInBegin => m_onFadeInBegin;
        public UnityEvent OnFadeInEnd => m_onFadeInEnd;
        public UnityEvent OnFadeOutBegin => m_onFadeOutBegin;
        public UnityEvent OnFadeOutEnd => m_onFadeOutEnd;

        private void Awake()
        {
            if (!m_fadeImage)
            {
                throw new NullReferenceException("Fade image is not asigned!");
            }
        }

        private void Start()
        {
            if (m_unfadeOnStart) FadeOut();
        }

        public void FadeIn()
        {
            DoFade(1f, m_onFadeInBegin, m_onFadeInEnd);
        }

        public void FadeOut()
        {
            DoFade(0f, m_onFadeOutBegin, m_onFadeOutEnd);
        }

        private void DoFade(float alpha, UnityEvent fadeBeginEvent, UnityEvent fadeEndEvent)
        {
            m_fadeImage.DOFade(alpha, m_fadeDuration)
                    .OnStart(() => { m_onFadeBegin?.Invoke(); fadeBeginEvent?.Invoke(); })
                    .OnComplete(() => { m_onFadeEnd?.Invoke(); fadeEndEvent?.Invoke(); });
        }
    }
}