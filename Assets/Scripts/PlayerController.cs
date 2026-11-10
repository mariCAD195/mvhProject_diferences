using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _mouseSensitivity;
    private CharacterController _characterController;
    private Vector2 _moveInput;

    [SerializeField] private float _maxAngle;
    private float  _currentAngle;

    private float _gravitionalAcceleration = 9.8f;
    private float _yVelocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 move = transform.forward * _moveInput.y + transform.right * _moveInput.x;
        move *= Time.deltaTime;
        move *= _moveSpeed;
        
        if(_characterController)
        {
            _yVelocity = 0;
        }
        else
        {
            _yVelocity = _gravitionalAcceleration * Time.deltaTime;
        }
        
        move += Vector3.down * _yVelocity * Time.deltaTime;
        _characterController.Move(move);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext ctx)
    {
        Vector2 rotation = ctx.ReadValue<Vector2>();
        rotation *= Time.deltaTime;
        rotation *= _mouseSensitivity;
        transform.Rotate(new Vector3(0, rotation.x, 0));
        
        _currentAngle = Mathf.Clamp(_currentAngle + rotation.y, -_maxAngle, _maxAngle);
        Camera.main.transform.localRotation = Quaternion.Euler(new  Vector3(-_currentAngle, 0, 0));
    }
}
