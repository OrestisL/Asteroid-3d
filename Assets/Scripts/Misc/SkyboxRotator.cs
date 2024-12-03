using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    public Material SkyboxMat;
    public float RotationSpeed;
    private float _totalRotation = 52.0f;

    private void Update()
    {
        _totalRotation += Time.deltaTime * RotationSpeed;
        SkyboxMat.SetFloat("_Rotation", _totalRotation);
    }
}
