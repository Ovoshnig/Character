using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    [SerializeField] private MessageDisplayer _messageDisplayer;

    private PlayerInput _playerInput;
    private Interactable _interactable;
    private string _interactionZoneEnteredMessage;
    private bool _isInInteractionZone;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            _interactable = interactable;
            _isInInteractionZone = true;
            _messageDisplayer.DisplayInteractionZoneEntered(_interactionZoneEnteredMessage);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out _))
        {
            _interactable = null;
            _isInInteractionZone = false;
            _messageDisplayer.DisplayInteractionZoneExit(string.Empty);
        }
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Interact.performed += TryInteract;
        _interactionZoneEnteredMessage = $"Нажмите {_playerInput.Player.Interact.GetBindingDisplayString()} для взаимодействия";
    }

    private void OnEnable() => _playerInput.Enable();

    private void OnDisable() => _playerInput.Disable();

    private void TryInteract(InputAction.CallbackContext _)
    {
        if (_isInInteractionZone)
            Interact();
    }

    private void Interact()
    {
        _interactable.React();
    }
}
