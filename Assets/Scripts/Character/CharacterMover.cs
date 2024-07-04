using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private Vector2 _moveInput;
    private Vector2 _rotateInput;

    public void HandleMovement()
    {
        Move();
        Rotate();
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _playerInput = new PlayerInput();
        _playerInput.Player.Move.performed += OnMovePerformed;
        _playerInput.Player.Move.canceled += OnMoveCancelled;
        _playerInput.Player.Rotate.performed += OnRotatePerformed;
        _playerInput.Player.Rotate.canceled += OnRotateCancelled;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable() => _playerInput.Enable();
    private void OnDisable() => _playerInput.Disable();

    private void OnMovePerformed(InputAction.CallbackContext context) => _moveInput = context.action.ReadValue<Vector2>();
    private void OnMoveCancelled(InputAction.CallbackContext context) => _moveInput = Vector2.zero;
    private void OnRotatePerformed(InputAction.CallbackContext context) => _rotateInput = context.action.ReadValue<Vector2>();
    private void OnRotateCancelled(InputAction.CallbackContext context) => _rotateInput = Vector2.zero;

    private void Move()
    {
        Vector3 translation = _walkSpeed * Time.deltaTime * new Vector3(_moveInput.x, 0f, _moveInput.y);
        translation = transform.TransformDirection(translation);
        _rigidbody.velocity = translation;
    }

    private void Rotate()
    {
        Vector3 angularVelocity = _rotateSpeed * Time.deltaTime * new Vector3(0f, _rotateInput.x, 0f);
        _rigidbody.angularVelocity =  angularVelocity;
    }
}
