using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float Damage;
    public LayerMask HitLayers;
    [Range(1.0f, 20.0f)]
    public float RadiusOfEffect = 1.0f;
    public float LifeTime = 20.0f;

    protected float MovementSpeed = 25.0f;
    protected float RotationSpeed = 50.0f;
    private float _rotAngle;

    public GameObject DeathParticle;
    public AudioClip DeathSound;

    private AudioSource _audioSource;

    protected virtual void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();

        Destroy(gameObject, LifeTime);
    }

    private void Update()
    {
        transform.position += Time.deltaTime * Vector3.forward * MovementSpeed;
        transform.localRotation = Quaternion.AngleAxis(_rotAngle, Vector3.forward);
        _rotAngle += Time.deltaTime * RotationSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] others = Physics.OverlapSphere(transform.position, RadiusOfEffect, HitLayers);

        for (int i = 0; i < others.Length; i++)
        {
            others[i].GetComponent<Asteroid>().DoDamage(Damage);
        }

        _audioSource.PlayOneShot(DeathSound);
        Destroy(gameObject, 2.0f);
    }
}
