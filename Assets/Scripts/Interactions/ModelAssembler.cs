using UnityEngine;
using UnityEngine.Events;

public class ModelAssembler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent m_onModelAssembled;
    [SerializeField] private UnityEvent m_onModelDisassembled;

    public bool IsAssembled
    {
        get; 
        private set;
    } = true;

    public UnityEvent OnModelAssembled => m_onModelAssembled;
    public UnityEvent OnModelDisassembled => m_onModelDisassembled;

    public void Assemble()
    {
        IsAssembled = true;
        m_onModelAssembled?.Invoke();
    }

    public void Disassemble()
    {
        IsAssembled = false;
        m_onModelDisassembled?.Invoke();
    }

    public void SwitchActivity()
    {   
        if (IsAssembled) Disassemble();
        else Assemble();
    }
}
