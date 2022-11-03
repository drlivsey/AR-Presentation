using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

namespace ARPresentation
{
    public class Fader : MonoBehaviour
    {
        [SerializeField] private Image m_fadeImage;
        [SerializeField, Min(0.1f)] private float m_fadeDuration = 1f;

        [Header("Events")]
        [SerializeField] private UnityEvent m_onFadeBegin;
        [SerializeField] private UnityEvent m_onFadeEnd;

        public UnityEvent OnFadeBegin => m_onFadeBegin;
        public UnityEvent OnFadeEnd => m_onFadeEnd;

        private void Awake()
        {
            if (!m_fadeImage)
            {
                throw new NullReferenceException("Fade image is not asigned!");
            }
        }

        public void FadeIn()
        {
            DoFade(1f);
        }

        public void FadeOut()
        {
            DoFade(0f);
        }

        private void DoFade(float alpha)
        {
            m_fadeImage.DOFade(alpha, m_fadeDuration)
                    .OnStart(() => m_onFadeBegin?.Invoke())
                    .OnComplete(() => m_onFadeEnd?.Invoke());
        }
    }
}