using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class PhysicsButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent m_onClick;

    public UnityEvent OnClick => m_onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        m_onClick?.Invoke();
    }
}
