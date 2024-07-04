using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    private PlayerInput _playerInput;
    private bool _isInInteractionZone;
    private Interactable _interactable;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Interact.performed += TryInteract;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable))
        {
            _interactable = interactable;
            _isInInteractionZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out _))
        {
            _interactable = null;
            _isInInteractionZone = false;
        }
    }
}
