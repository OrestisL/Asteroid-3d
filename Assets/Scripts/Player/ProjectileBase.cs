using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float Damage;
    public LayerMask HitLayers;
    [Range(1.0f, 20.0f)]
    public float RadiusOfEffect = 1.0f;
    public float LifeTime = 20.0f;

    public GameObject DeathParticle;
    public AudioClip DeathSound;

    private AudioSource _audioSource;

    protected virtual void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] others = Physics.OverlapSphere(transform.position, RadiusOfEffect, HitLayers);

        for (int i = 0; i < others.Length; i++)
        {
            others[i].GetComponent<Asteroid>().DoDamage(Damage);
        }

        _audioSource.PlayOneShot(DeathSound);
        Destroy(gameObject, 5f);
    }
}
