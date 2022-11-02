using System;
using UnityEngine;

using ARPresentation.Enums;

namespace ARPresentation.Tweeners
{
    public abstract class BaseTweener : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField] private Transform m_tweenTarget = null;
        [SerializeField] private float m_tweenDuration = 1f;
        [SerializeField] private CoordinatesTypes m_tweenCoordinates;
        [SerializeField] private Vector3 m_beginPoint;
        [SerializeField] private Vector3 m_endPoint;

        private void Awake()
        {
            if (!m_tweenTarget) m_tweenTarget = this.transform;
        }

        public void TweenToBeginPoint()
        {
            TweenToPoint(m_beginPoint);
        }

        public void TweenToEndPoint()
        {
            TweenToPoint(m_endPoint);
        }

        private void TweenToPoint(Vector3 point) 
        {
            if (!m_tweenTarget)
            {
                throw new NullReferenceException("Tween target is null!");
            }

            if (m_tweenCoordinates == CoordinatesTypes.Local)
            {
                TweenLocal(m_tweenTarget, point, m_tweenDuration);
            }
            else if (m_tweenCoordinates == CoordinatesTypes.Global)
            {
                TweenGlobal(m_tweenTarget, point, m_tweenDuration);
            }
        }

        protected abstract void TweenLocal(Transform target, Vector3 point, float duration);
        protected abstract void TweenGlobal(Transform target, Vector3 point, float duration);
    }
}