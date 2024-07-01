using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _playerInput;
    private Vector2 _moveInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Move.performed += OnMovePerformed;
        _playerInput.Player.Move.canceled += OnMoveCancelled;
    }

    private void OnEnable() => _playerInput.Enable();

    private void OnDisable() => _playerInput.Disable();

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.action.ReadValue<Vector2>();
    }

    private void OnMoveCancelled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    private void Update()
    {
        Vector3 translation = _speed * Time.deltaTime * new Vector3(_moveInput.x, 0, _moveInput.y);
        transform.Translate(translation);
    }
}
