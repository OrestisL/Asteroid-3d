using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Health;
    private float _maxHealth;

    public GameObject DeathParticle;
    public AudioClip DeathSound;
    private AudioSource _audioSource;

    [SerializeField]
    private Gradient _asteroidColor;
    private Material _asteroidMat;
    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _asteroidMat = GetComponent<Renderer>().material;
        _maxHealth = Health;

        _asteroidMat.SetColor("_Color", _asteroidColor.Evaluate(1));
    }

    public void DoDamage(float damage) 
    {
        Health -= damage;
        _asteroidMat.SetColor("_Color", _asteroidColor.Evaluate(Health / _maxHealth));

        if (Health <= 0) 
        {
            Instantiate(DeathParticle, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(DeathSound);
            Destroy(gameObject, 5f);
        }
    }
}
