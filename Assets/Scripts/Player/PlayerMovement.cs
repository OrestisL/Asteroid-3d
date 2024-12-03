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

    private void Start()
    {
        Controller = GetComponent<CharacterController>();

        _moveAction = InputSystem.actions.FindAction("Move");

        var _runAction = InputSystem.actions.FindAction("Sprint");
        _runAction.started += (_) => { _running = true; _source.pitch = RunPitch; };
        _runAction.canceled += (_) => { _running = false; _source.pitch = WalkPitch; };

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
    }

    private void Move(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        Vector3 inputDirection = new Vector3(x, y, 1);

        Controller.Move(Time.deltaTime * CurrentSpeed * inputDirection);
    }
}
