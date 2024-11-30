using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Health;
    // add some gui stuff here
    public GameObject DeathParticle;
    public AudioClip DeathSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void DoDamage(float damage) 
    {
        Health -= damage;
        // update gui
        if (Health <= 0) 
        {
            Instantiate(DeathParticle, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(DeathSound);
            Destroy(gameObject, 5f);
        }
    }
}
