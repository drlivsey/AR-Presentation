using UnityEngine;
using DG.Tweening;

namespace ARPresentation.Tweeners
{
    public class PositionTweener : BaseTweener
    {
        protected override void TweenLocal(Transform target, Vector3 point, float duration)
        {
            target.DOLocalMove(point, duration);
        }

        protected override void TweenGlobal(Transform target, Vector3 point, float duration)
        {
            target.DOMove(point, duration);
        }
    }
}