using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = GameObject.FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        transform.position += Time.deltaTime * _playerMovement.CurrentSpeed * Vector3.forward;
    }
}
