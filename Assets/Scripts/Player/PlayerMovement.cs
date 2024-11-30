using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    [SerializeField]
    private float WalkSpeed;
    [SerializeField]
    private float RunSpeed;
    private bool _running;
    public float CurrentSpeed => _running ? RunSpeed : WalkSpeed;

    private InputAction _moveAction;
    private InputAction _runAction;
    [SerializeField]
    private Camera _mainCam;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();

        _moveAction = InputSystem.actions.FindAction("Move");

        _runAction = InputSystem.actions.FindAction("Sprint");
        _runAction.started += (_) => _running = true;
        _runAction.canceled += (_) => _running = false;

        _mainCam = Camera.main;
    }

    private void Update()
    {
        Vector2 move = _moveAction.ReadValue<Vector2>();
        Move(move);
    }

    private void Move(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 inputDirection = new Vector3(x, y, 1);

        Controller.Move(Time.deltaTime * CurrentSpeed * inputDirection);
    }
}
