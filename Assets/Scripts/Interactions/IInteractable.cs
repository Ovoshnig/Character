using UnityEngine;

public interface IInteractable
{
}

public abstract class Interactable : MonoBehaviour, IInteractable
{
    protected string Message = "��������� ��������������";

    [SerializeField] private MessageDisplayer _messageDisplayer;

    public virtual void React() => _messageDisplayer.Display(Message);
}
