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

    // sounds
    public AudioClip EngineSound;
    public float WalkPitch, RunPitch;
    private AudioSource _source;

    [SerializeField]
    private bool _inputEnabled = false;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();

        _moveAction = InputSystem.actions.FindAction("Move");

        if (!_inputEnabled)
        {
            var _runAction = InputSystem.actions.FindAction("Sprint");
            _runAction.performed += Sprint;
            _runAction.canceled += Sprint;
        }
        _source = GetComponent<AudioSource>();
        _source.pitch = WalkPitch;
        _source.clip = EngineSound;
        _source.loop = true;
        _source.Play();
    }

    private void Update()
    {
        Vector2 move = _moveAction.ReadValue<Vector2>();
        Move(move);

        if (_inputEnabled)
            ScoreManager.Instance.AddScore(Time.deltaTime);
    }

    private void Move(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 inputDirection = _inputEnabled ? new Vector3(x, y, 1) : Vector3.forward;

        Controller.Move(Time.deltaTime * CurrentSpeed * inputDirection);
    }

    private void Sprint(InputAction.CallbackContext ctx)
    {
        bool isButtonPressed = ctx.phase == InputActionPhase.Performed;

        _running = isButtonPressed;
        _source.pitch = isButtonPressed ? RunPitch : WalkPitch;
    }

    private void OnDestroy()
    {
        var _runAction = InputSystem.actions.FindAction("Sprint");
        _runAction.performed -= Sprint;
        _runAction.canceled -= Sprint;
    }
}
