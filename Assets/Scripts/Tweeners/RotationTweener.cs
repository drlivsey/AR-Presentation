using UnityEngine;
using DG.Tweening;

namespace ARPresentation.Tweeners
{
    public class RotationTweener : BaseTweener
    {
        protected override void TweenLocal(Transform target, Vector3 point, float duration)
        {
            target.DOLocalRotate(point, duration);
        }

        protected override void TweenGlobal(Transform target, Vector3 point, float duration)
        {
            target.DORotate(point, duration);
        }
    }
}